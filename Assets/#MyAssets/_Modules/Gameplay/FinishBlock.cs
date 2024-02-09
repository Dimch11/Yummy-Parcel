using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
