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
    [Inject]
    CurrentLevel currentLevel;
    [Inject]
    PlayerProgress playerProgress;

    public void Win()
    {
        if (!gameOver.Value)
        {
            gameOver.Value = true;

            playerProgress.SetLevelState(currentLevel.Num, new LevelState(true));

            resultScreen.Show();
        }
    }
}
