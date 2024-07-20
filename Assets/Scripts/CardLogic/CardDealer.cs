using UnityEngine;
using System.Collections.Generic;
using Model;
using Zenject;

public sealed class CardDealer : MonoBehaviour
{   
    [Inject] private TurnManager _turnManager;
    [SerializeField] private CardPileModel _drawPile;
    [SerializeField] private CardPileModel _discardPile;
    [SerializeField] private Hand _hand;
    [SerializeField] private int _cardsDealtPerTurn = 5;

    private void Awake()
    {
        _turnManager.BattleEnded += ShuffleFromDiscardPileIntoDrawPile;
        _turnManager.RoundStarted += DealCards;
        _turnManager.PlayerTurnEnded += _hand.DiscardAllCards;

        _hand.CardDiscarded += DiscardCard;
    }

    public void SetInitialDeck(Deck initialDeck)
    {
        _drawPile.Add(initialDeck.Cards);
        _drawPile.Shuffle();
    }

    private void ShuffleFromDiscardPileIntoDrawPile()
    {
        List<CardData> discardedCards = _discardPile.GetAndRemoveAll();
    
        _drawPile.Add(discardedCards);
        _drawPile.Shuffle();
    }

    private void DealCards()
    {
        List<CardData> cardsToDeal = GetCardsToDeal();

        _hand.AddCards(cardsToDeal);
    }
    
    private List<CardData> GetCardsToDeal()
    {
        List<CardData> cardsToDeal = new();

        if (_drawPile.CardsAmount >= _cardsDealtPerTurn)
        {
            cardsToDeal.AddRange(_drawPile.GetAndRemove(_cardsDealtPerTurn));
        }
        else 
        {
            int cardsToAddLater = _cardsDealtPerTurn - _drawPile.CardsAmount;

            cardsToDeal.AddRange(_drawPile.GetAndRemoveAll());

            ShuffleFromDiscardPileIntoDrawPile();

            cardsToDeal.AddRange(_drawPile.GetAndRemove(cardsToAddLater));
        }

        return cardsToDeal;
    }

    private void DiscardCard(CardData cardData)
    {
        _discardPile.Add(cardData);
    }
}
