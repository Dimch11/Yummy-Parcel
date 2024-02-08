using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class CurrentScoreUI : MonoBehaviour
{
    public string format;
    TMP_Text scoreText;

    [Inject]
    Score score;

    void Start()
    {
        scoreText = GetComponentInChildren<TMP_Text>();

        score.CurrentScore
            .StartWith(score.CurrentScore.Value)
            .Subscribe(_ =>
            {
                scoreText.text = string.Format(format, (int)score.CurrentScore.Value);
            })
            .AddTo(this);
    }
}
