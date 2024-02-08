using UnityEngine;
using Zenject;

public class LevelsInstaller : MonoInstaller
{
    [Inject]
    GameplaySettings gameplaySettings;

    public override void InstallBindings()
    {
        Container.Bind<CurrentLevel>().FromNew().AsSingle().NonLazy();
        BindPlayerProgress();
    }

    void BindPlayerProgress()
    {
        var emptyPlayerProgress = new PlayerProgress();
        emptyPlayerProgress.ResetProgress(gameplaySettings.numberOfLevels);
        var emptyPlayerProgressStr = JsonUtility.ToJson(emptyPlayerProgress);

        var playerProgressStr = PlayerPrefs.GetString(PlayerProgress.playerPrefsName, emptyPlayerProgressStr);
        var playerProgress = JsonUtility.FromJson<PlayerProgress>(playerProgressStr);
        Container.Bind<PlayerProgress>().FromInstance(playerProgress);
    }
}