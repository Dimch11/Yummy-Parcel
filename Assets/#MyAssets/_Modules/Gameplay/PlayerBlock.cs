using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerBlock : MonoBehaviour
{
    [HideInInspector]
    public bool touchesStaticBlock = true;

    Rigidbody2D rb;

    [Inject]
    ArrowController arrowController;
    [Inject]
    GameplaySettings gameplaySettings;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        arrowController.left
            .Where(_ => touchesStaticBlock)
            .Subscribe(_ =>
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = Vector2.left * gameplaySettings.speed;
                SetSmallerCollider();
            })
            .AddTo(this);

        arrowController.right
            .Where(_ => touchesStaticBlock)
            .Subscribe(_ =>
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = Vector2.right * gameplaySettings.speed;
                SetSmallerCollider();
            })
            .AddTo(this);

        arrowController.up
            .Where(_ => touchesStaticBlock)
            .Subscribe(_ =>
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = Vector2.up * gameplaySettings.speed;
                SetSmallerCollider();
            })
            .AddTo(this);

        arrowController.down
            .Where(_ => touchesStaticBlock)
            .Subscribe(_ =>
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = Vector2.down * gameplaySettings.speed;
                SetSmallerCollider();
            })
            .AddTo(this);
    }

    public void SetSmallerCollider()
    {
        transform.DOScale(0.98f, 0f).SetLink(gameObject);
    }

    public void SetStandartCollider()
    {
        transform.DOScale(1f, 0.1f).SetLink(gameObject);
    }
}
