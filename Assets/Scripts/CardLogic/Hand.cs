using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using Model;

public sealed class Hand : MonoBehaviour
{
    [Inject] private TeamsContainer _teamsContainer;
    [Inject] private CardObjectPool _cardPool;
    [Inject] private CardPlayer _cardPlayer;
    [SerializeField] private Transform _cardsParentObject;
    private List<CardModel> _cardModels = new();

    public Action<CardData> CardDiscarded;

    public void AddCards(List<CardData> cardsToAdd)
    {
        foreach (CardData data in cardsToAdd)
        {
            AddCard(data);
        }
    }

    public void AddCard(CardData data)
    {
        CardModel cardModel = _cardPool.GetPooledObject(_cardsParentObject);
        cardModel.SetCardData(data);
        cardModel.CardPlayed += TryToPlayAndRemoveCard;

        _cardModels.Add(cardModel);
    }

    public void DiscardAllCards()
    {
        foreach (CardModel cardModel in _cardModels)
        {
            DiscardAndRemoveCard(cardModel);
        }

        _cardModels = new();
    }

    private void TryToPlayAndRemoveCard(CardModel cardModel)
    {
        if (_cardPlayer.IsPossibleToPlayCard(cardModel.Data))
        {   
            DiscardAndRemoveCard(cardModel);
            
            _cardModels.Remove(cardModel);

            _cardPlayer.PlayCardWithEnergy(cardModel.Data, _teamsContainer.PlayerTeam);
        }
    }

    private void DiscardAndRemoveCard(CardModel cardModel)
    {
        DiscardCard(cardModel.Data);

        RemoveCard(cardModel);
    }

    private void RemoveCard(CardModel cardModel)
    {
        cardModel.CardPlayed -= TryToPlayAndRemoveCard;
        cardModel.ReturnObjectToPool();
    }

    private void DiscardCard(CardData data)
    {
        CardDiscarded.Invoke(data);
    }
}