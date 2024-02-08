using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class PlayerProgress
{
    public const string playerPrefsName = "playerProgress";

    [SerializeField]
    List<LevelState> levels;

    public void ResetProgress(int numOfLevels)
    {
        levels = new List<LevelState>();

        for (int i = 0; i < numOfLevels; i++)
        {
            levels.Add(new LevelState());
        }
    }

    public void SetLevelState(int levelNum, LevelState levelState)
    {
        if (levels[levelNum - 1].grade < levelState.grade || !levels[levelNum - 1].isCompleted)
        {
            levels[levelNum - 1] = levelState;
        }
        
        Save();
    }

    public LevelState GetLevelState(int levelNum)
    {
        return levels[levelNum - 1];
    }

    public int HighestCompletedLevel()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (!levels[i].isCompleted)
            {
                return i;
            }
        }

        return levels.Count;
    }

    public bool PlayerCompletedAllLevels()
    {
        return HighestCompletedLevel() == levels.Count;
    }


    void Save()
    {
        PlayerPrefs.SetString(playerPrefsName, JsonUtility.ToJson(this));
    }
}
