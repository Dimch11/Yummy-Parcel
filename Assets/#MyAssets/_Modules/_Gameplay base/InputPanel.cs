using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class InputPanel : MonoBehaviour
{
    public IObservable<Vector2> drag;
    public IObservable<Vector2> pointerDown;
    public IObservable<Vector2> pointerUp;

    ObservableDragTrigger dragTrigger;
    ObservablePointerDownTrigger pointerDownTrigger;
    ObservablePointerUpTrigger pointerUpTrigger;

    void Awake()
    {
        dragTrigger = gameObject.AddComponent<ObservableDragTrigger>();
        pointerDownTrigger = gameObject.AddComponent<ObservablePointerDownTrigger>();
        pointerUpTrigger = gameObject.AddComponent<ObservablePointerUpTrigger>();

        drag = dragTrigger
            .OnDragAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));

        pointerDown = pointerDownTrigger
            .OnPointerDownAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));

        pointerUp = pointerUpTrigger
            .OnPointerUpAsObservable()
            .Select(_ => (Vector2)Camera.main.ScreenToWorldPoint(_.position));
    }
}