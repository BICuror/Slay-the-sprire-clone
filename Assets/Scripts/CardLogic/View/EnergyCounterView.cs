using UnityEngine;
using TMPro;
using Model;

namespace View
{
    [RequireComponent(typeof(EnergyCounterModel))]

    public sealed class EnergyCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _energyTextField;

        private void Awake()
        {
            GetComponent<EnergyCounterModel>().EnergyUpdated += UpdateEnergyText;
        }

        private void UpdateEnergyText(int value)
        {
            _energyTextField.text = value.ToString();
        }
    }
}