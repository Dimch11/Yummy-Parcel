using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public ResultScreen resultScreen;
    public InputPanel inputPanel;

    public override void InstallBindings()
    {
        BindFromNew<Disposer>();
        BindFromInstance(resultScreen);
        BindFromInstance(inputPanel);
        BindFromNew<GameEnder>();

        Time.timeScale = 1;
    }

    void BindFromNew<T>()
    {
        Container.BindInterfacesAndSelfTo<T>().FromNew().AsSingle().NonLazy();
    }

    void BindFromInstance<T>(T instance)
    {
        Container.BindInterfacesAndSelfTo<T>().FromInstance(instance);
    }
}