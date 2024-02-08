using UniRx;
using UnityEngine;

public class Score
{
    public ReactiveProperty<float> CurrentScore { get; } = new(0);

    public float BestScore 
    { 
        get
        {
            return PlayerPrefs.GetFloat("Best score", 0f);
        }
        set
        {
            PlayerPrefs.SetFloat("Best score", value);
        }
    }

    public void AddToScore(float num)
    {
        CurrentScore.Value += num;

        if (CurrentScore.Value >  BestScore)
        {
            BestScore = CurrentScore.Value;
        }
    }
}
