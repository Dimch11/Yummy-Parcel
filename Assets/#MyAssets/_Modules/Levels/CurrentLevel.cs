using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CurrentLevel
{
    public int Num
    {
        get => level;

        set
        {
            if (value == 0)
            {
                if (playerProgress.PlayerCompletedAllLevels())
                {
                    level = gameplaySettings.numberOfLevels;
                }
                else
                {
                    level = playerProgress.HighestCompletedLevel() + 1;
                }
            }
            else if (value < 0 || value > gameplaySettings.numberOfLevels)
            {
                level = playerProgress.HighestCompletedLevel();
            }
            else
            {
                level = value;
            }
        }
    }

    int level;

    [Inject]
    GameplaySettings gameplaySettings;
    [Inject]
    PlayerProgress playerProgress;

    [Inject]
    void Construct()
    {
        Num = 0;
    }
}
