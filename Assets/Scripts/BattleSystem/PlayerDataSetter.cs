using UnityEngine;
using Zenject;

public sealed class PlayerDataSetter : MonoBehaviour
{   
    [Inject] private TeamsContainer _teamsContainer;
    [Inject] private CardDealer _cardDealer;
    [SerializeField] private EntityData _playerData;

    public void SetPlayerData()
    {
        _teamsContainer.PlayerTeam.Self.HealthModel.SetMaxHealth(_playerData.MaxHealth);
        _cardDealer.SetInitialDeck(_playerData.Deck);
    }
}