using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class ChangingParameter
{
    public float startValue;
    public float changeAmount;
    [ShowIf("@changeAmount < 0")]
    public float minValue;
    [ShowIf("@changeAmount > 0")]
    public float maxValue;

    bool firstTime = true;

    public float CurrentValue 
    { 
        get
        {
            if (firstTime)
            {
                Initialize();
                firstTime = false;
            }

            return currentValue;
        }
        private set
        {
            currentValue = value;
        }
    }
    float currentValue;

    void Initialize()
    {
        currentValue = startValue;

        if (changeAmount < 0)
        {
            maxValue = currentValue;
        }
        else if (changeAmount > 0)
        {
            minValue = currentValue;
        }
    }

    public void Next()
    {
        CurrentValue += changeAmount;

        if (CurrentValue < minValue)
        {
            CurrentValue = minValue;
        }
        if (CurrentValue > maxValue)
        {
            CurrentValue = maxValue;
        }
    }
}
