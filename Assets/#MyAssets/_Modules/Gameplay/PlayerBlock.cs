using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerBlock : MonoBehaviour
{
    Rigidbody2D rb;

    [Inject]
    ArrowController arrowController;
    [Inject]
    GameplaySettings gameplaySettings;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        arrowController.left
            .Subscribe(_ =>
            {
                rb.velocity = Vector2.left * gameplaySettings.speed;
            })
            .AddTo(this);

        arrowController.right
            .Subscribe(_ =>
            {
                rb.velocity = Vector2.right * gameplaySettings.speed;
            })
            .AddTo(this);

        arrowController.up
            .Subscribe(_ =>
            {
                rb.velocity = Vector2.up * gameplaySettings.speed;
            })
            .AddTo(this);

        arrowController.down
            .Subscribe(_ =>
            {
                rb.velocity = Vector2.down * gameplaySettings.speed;
            })
            .AddTo(this);
    }
}
