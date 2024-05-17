using DontStopTheTrain.UI;
using UnityEngine;
using Zenject;

public class UIMonoInstaller : MonoInstaller
{
    [SerializeField]
    private UIContainer _UIContainer;

    public override void InstallBindings()
    {
        Container.Bind<UIContainer>().FromInstance(_UIContainer).AsSingle();
    }
}