using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Model;

namespace View
{
    [RequireComponent(typeof(CardModel))]

    public sealed class CardView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _priceTextField;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _nameTextField;
        [SerializeField] private TextMeshProUGUI _descriptionTextField;

        private void Awake()
        {
            CardModel cardModel = GetComponent<CardModel>();
            
            cardModel.CardDataApplied += UpdateCardVisuals;
            _button.onClick.AddListener(cardModel.PlayCard);
        }

        public void UpdateCardVisuals(CardData data)
        {
            _priceTextField.text = data.Price.ToString();
            _iconImage.sprite = data.Icon;
            _nameTextField.text = data.Name;
            _descriptionTextField.text = data.Description;
        }
    }
}