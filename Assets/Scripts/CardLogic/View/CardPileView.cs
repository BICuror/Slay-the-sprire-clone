using TMPro;
using UnityEngine;
using Model;

namespace View
{
    [RequireComponent(typeof(CardPileModel))]
    
    public sealed class CardPileView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cardsAmountTextField;

        private void Awake()
        {
            GetComponent<CardPileModel>().CardsAmountChanged += UpdateCardsAmountText;
        }

        private void UpdateCardsAmountText(int currentCardsAmount)
        {
            _cardsAmountTextField.text = currentCardsAmount.ToString();
        }
    }
}