using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameOverCollider : MonoBehaviour
{
    [Inject]
    ScenesController scenesController;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scenesController.LoadScene(Scenes.Gameplay);
        }
    }
}
