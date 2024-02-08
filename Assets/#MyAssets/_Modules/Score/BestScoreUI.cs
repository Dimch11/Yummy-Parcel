using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class BestScoreUI : MonoBehaviour
{
    public string format;
    TMP_Text scoreText;

    [Inject]
    Score score;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = string.Format(format, score.BestScore);

        score.CurrentScore
            .StartWith(score.CurrentScore.Value)
            .Subscribe(_ =>
        {
            Observable.NextFrame()
                .Subscribe(_ => scoreText.text = string.Format(format, (int)score.BestScore))
                .AddTo(this);
        })
        .AddTo(this);
    }
}
