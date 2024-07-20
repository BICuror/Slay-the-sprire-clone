using UnityEngine;
using Zenject;

public sealed class BattleSystemInstaller : MonoInstaller
{
    [SerializeField] private EncounterManager _encounterManager;
    [SerializeField] private TeamsContainer _teamsContainer;
    
    public override void InstallBindings()
    {
        Container.Bind<EncounterManager>().FromInstance(_encounterManager).AsSingle().NonLazy();
        Container.Bind<TeamsContainer>().FromInstance(_teamsContainer).AsSingle().NonLazy();
    }    
}
