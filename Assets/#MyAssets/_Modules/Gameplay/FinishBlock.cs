using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FinishBlock : MonoBehaviour
{
    [Inject]
    GameEnder gameEnder;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            GetComponentInChildren<ParticleSystem>().Play();

            gameEnder.Win();
        }
    }
}
