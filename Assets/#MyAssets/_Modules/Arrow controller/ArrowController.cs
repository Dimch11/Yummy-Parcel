using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    public IObservable<Unit> right;
    public IObservable<Unit> left;
    public IObservable<Unit> up;
    public IObservable<Unit> down;

    [SerializeField]
    Button leftButton;
    [SerializeField]
    Button rightButton;
    [SerializeField]
    Button upButton;
    [SerializeField]
    Button downButton;

    void Awake()
    {
        right = rightButton.OnClickAsObservable();
        left = leftButton.OnClickAsObservable();
        up = upButton.OnClickAsObservable();
        down = downButton.OnClickAsObservable();
    }
}
