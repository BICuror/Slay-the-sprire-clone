using UnityEngine;
using Zenject;

public sealed class EntryPoint : MonoBehaviour
{
    [Inject] private TeamsContainer _teamsContainer;
    [Inject] private EncounterManager _encounterManager;
    [SerializeField] private EntityData _playerData;
    [SerializeField] private CardDealer _cardDealer;

    private void Start()
    {
        SetPlayerData();

        _encounterManager.StartRun();
    }

    private void SetPlayerData()
    {
        _teamsContainer.PlayerTeam.Self.HealthModel.SetMaxHealth(_playerData.MaxHealth);
        _cardDealer.SetInitialDeck(_playerData.Deck);
    }
}
