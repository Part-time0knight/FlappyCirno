using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Settings settings;
    public override void InstallBindings()
    {
        Container.BindInstance<Settings>(settings).AsSingle();
        Container.BindInterfacesTo<LoadController>().AsSingle();
    }
    
}