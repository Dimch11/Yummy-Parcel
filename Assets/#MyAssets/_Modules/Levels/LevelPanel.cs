using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelPanel : MonoBehaviour
{
    public int levelNum;

    [Header("Internal")]
    public List<Button> clickableParts;
    public TMP_Text levelText;
    public string levelTextFormat = "{0}";
    public List<GameObject> other;

    LevelState levelState;

    [Inject]
    PlayerProgress playerProgress;
    [Inject]
    CurrentLevel currentLevel;

    void Start()
    {
        UpdateView();
        SubscribeOnClickables();
    }

    void SubscribeOnClickables()
    {
        foreach (var clickable in clickableParts)
        {
            clickable.onClick.AddListener(() =>
            {
                currentLevel.Num = levelNum;
            });
        }
    }

    void UpdateView()
    {
        levelState = playerProgress.GetLevelState(levelNum);

        UpdateClickableParts();
        UpdateText();
        UpdateOther();
    }

    void UpdateClickableParts()
    {
        foreach (var clickablePart in clickableParts)
        {
            if (levelState.isCompleted || levelNum == 1 || levelNum == playerProgress.HighestCompletedLevel() + 1)
            {
                clickablePart.interactable = true;
            }
            else
            {
                clickablePart.interactable = false;
            }
        }
    }

    void UpdateText()
    {
        levelText.text = string.Format(levelTextFormat, levelNum);
    }

    void UpdateOther()
    {
        if (other.Count > 0)
        {
            other[0].GetComponent<IGradeInStars>()?.SetGrade(levelState.grade);
        }
    }
}
