using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Model
{
    public sealed class CardPileModel : MonoBehaviour
    {
        private List<CardData> _containedCards = new();

        public Action<int> CardsAmountChanged;

        public int CardsAmount => _containedCards.Count;

        public void Add(CardData card)
        {
            _containedCards.Add(card);
        
            InvokeCardsAmountChanged();
        }

        public void Add(List<CardData> cards)
        {
            _containedCards.AddRange(cards);
        
            InvokeCardsAmountChanged();
        }

        public List<CardData> GetAndRemoveAll() => GetAndRemove(CardsAmount);

        public List<CardData> GetAndRemove(int amount)
        {
            List<CardData> takenCards = _containedCards.GetRange(0, amount);

            _containedCards.RemoveRange(0, amount);

            InvokeCardsAmountChanged();

            return takenCards;
        }
        
        public void Shuffle()
        {
            _containedCards = _containedCards.OrderBy(x => Random.Range(0, _containedCards.Count)).ToList();
        }

        private void InvokeCardsAmountChanged()
        {
            CardsAmountChanged.Invoke(_containedCards.Count);
        }    
    }
}

