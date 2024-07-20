using UnityEngine;
using Zenject;
using Model;

public sealed class CardSystemInstaller : MonoInstaller
{
    [SerializeField] private CardPlayer _cardPlayer;
    [SerializeField] private CardDealer _cardDealer;
    [SerializeField] private CardObjectPool _cardObjectPool;
    
    public override void InstallBindings()
    {
        Container.Bind<CardPlayer>().FromInstance(_cardPlayer).AsSingle().NonLazy();
        Container.Bind<CardDealer>().FromInstance(_cardDealer).AsSingle().NonLazy();
        Container.Bind<CardObjectPool>().FromInstance(_cardObjectPool).AsSingle().NonLazy();
    }    
}
