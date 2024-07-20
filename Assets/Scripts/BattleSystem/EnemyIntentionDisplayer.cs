using UnityEngine;
using System.Collections.Generic;
using Model;
using Zenject;

public sealed class EnemyIntentionDisplayer : MonoBehaviour
{
    [Inject] private CardObjectPool _cardPool;
    [SerializeField] private Transform _cardsParentObject;
    private List<CardModel> _cardModels = new();

    public void SetCardIntentions(List<CardData> cardDatas)
    {
        foreach (CardData data in cardDatas)
        {
            CardModel cardModel = _cardPool.GetPooledObject(_cardsParentObject);
            cardModel.SetCardData(data);
            _cardModels.Add(cardModel);
        }
    }

    public void ClearCardIntentions()
    {
        foreach (CardModel cardModel in _cardModels)
        {
            cardModel.ReturnObjectToPool();
        }

        _cardModels = new();
    }
}
