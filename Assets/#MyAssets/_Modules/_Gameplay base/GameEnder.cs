using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class GameEnder
{
    public ReactiveProperty<bool> gameOver = new();

    [Inject]
    ResultScreen resultScreen;

    public void EndGame()
    {
        if (!gameOver.Value)
        {
            gameOver.Value = true;

            resultScreen.Show();
        }
    }
}
