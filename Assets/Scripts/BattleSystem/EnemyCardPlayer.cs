using UnityEngine;
using System.Collections.Generic;
using Zenject;

public sealed class EnemyCardPlayer : MonoBehaviour
{
    [Inject] private TeamsContainer _teamsContainer;
    [Inject] private TurnManager _turnManager;
    [Inject] private CardPlayer _cardPlayer;
    [SerializeField] private int _cardsPlayedPerTurn;
    [SerializeField] private EnemyIntentionDisplayer _enemyIntentionDisplayer;
    private List<CardData> _cardsToPlay;
    private Deck _deck;

    private void Awake()
    {
        _turnManager.RoundStarted += PresentCardsToPlay;
        _turnManager.EnemyTurnStarted += PlayCards;
        _turnManager.PlayerTurnEnded += _enemyIntentionDisplayer.ClearCardIntentions;
    }

    public void SetDeck(Deck deck) => _deck = deck;

    private void PresentCardsToPlay()
    {
        _cardsToPlay = _deck.Cards.GetRange(0, 2);
        _enemyIntentionDisplayer.SetCardIntentions(_cardsToPlay);
    }

    private void PlayCards()
    {
        for (int i = 0; i < _cardsToPlay.Count; i++)
        {
            _cardPlayer.PlayCard(_cardsToPlay[i], _teamsContainer.EnemyTeam);
        }
    }
}
