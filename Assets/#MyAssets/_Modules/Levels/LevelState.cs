using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelState
{
    public bool isCompleted;
    public int grade;

    public LevelState(bool isCompleted, int grade)
    {
        this.isCompleted = isCompleted;
        this.grade = grade;
    }

    public LevelState(bool isCompleted)
    {
        this.isCompleted = isCompleted;
        this.grade = 0;
    }
}
