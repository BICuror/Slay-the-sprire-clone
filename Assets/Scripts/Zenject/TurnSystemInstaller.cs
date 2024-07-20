using UnityEngine;
using Zenject;

public sealed class TurnSystemInstaller : MonoInstaller
{
    [SerializeField] private TurnManager _turnManager;
    
    public override void InstallBindings()
    {
        Container.Bind<TurnManager>().FromInstance(_turnManager).AsSingle().NonLazy();
    }    
}
