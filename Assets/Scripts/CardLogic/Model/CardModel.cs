using UnityEngine;
using System;

namespace Model
{
    public sealed class CardModel : PoolObject
    {
        private CardData _currentCardData;

        public Action<CardData> CardDataApplied;
        public Action<CardModel> CardPlayed;

        public CardData Data => _currentCardData;

        public void SetCardData(CardData cardData)
        {
            _currentCardData = cardData;

            CardDataApplied?.Invoke(cardData);
        }

        public void PlayCard() => CardPlayed?.Invoke(this);
    }
}
