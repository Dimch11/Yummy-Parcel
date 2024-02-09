using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerBlock : MonoBehaviour
{
    [HideInInspector]
    public bool canJump = true;

    Rigidbody2D rb;

    [Inject]
    ArrowController arrowController;
    [Inject]
    GameplaySettings gameplaySettings;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        arrowController.left
            .Where(_ => canJump)
            .Subscribe(_ =>
            {
                canJump = false;
                rb.velocity = Vector2.left * gameplaySettings.speed;
            })
            .AddTo(this);

        arrowController.right
            .Where(_ => canJump)
            .Subscribe(_ =>
            {
                canJump = false;
                rb.velocity = Vector2.right * gameplaySettings.speed;
            })
            .AddTo(this);

        arrowController.up
            .Where(_ => canJump)
            .Subscribe(_ =>
            {
                canJump = false;
                rb.velocity = Vector2.up * gameplaySettings.speed;
            })
            .AddTo(this);

        arrowController.down
            .Where(_ => canJump)
            .Subscribe(_ =>
            {
                canJump = false;
                rb.velocity = Vector2.down * gameplaySettings.speed;
            })
            .AddTo(this);
    }
}
