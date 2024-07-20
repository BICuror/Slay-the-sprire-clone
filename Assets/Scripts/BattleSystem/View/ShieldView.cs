using UnityEngine;
using TMPro;
using Model;

namespace View
{
    [RequireComponent(typeof(ShieldModel))]
    
    public sealed class ShieldView : MonoBehaviour
    {
        [SerializeField] private GameObject _shieldPresenterObject;
        [SerializeField] private TextMeshProUGUI _shieldChargesTextField;

        private void Awake()
        {
            GetComponent<ShieldModel>().ShieldChargesUpdated += UpdateShieldView;
        }

        private void UpdateShieldView(int shieldCharges)
        {
            _shieldChargesTextField.text = shieldCharges.ToString();
            _shieldPresenterObject.SetActive(shieldCharges > 0);
        }    
    }
}