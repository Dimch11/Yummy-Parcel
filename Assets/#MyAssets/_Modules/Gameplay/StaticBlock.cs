using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerBlock>().touchesStaticBlock = true;
            collision.gameObject.GetComponent<PlayerBlock>().SetStandartCollider();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerBlock>().touchesStaticBlock = false;
        }
    }
}
