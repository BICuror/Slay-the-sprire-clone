using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Model;

namespace View
{
    [RequireComponent(typeof(HealthModel))]
    
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private Slider _healthBar;
        private HealthModel _healthModel;

        private void Awake()
        {
            _healthModel = GetComponent<HealthModel>();

            _healthModel.HealthUpdated += UpdateHealthBar;
        }

        private void UpdateHealthBar(int currentHealth)
        {
            _healthText.text = $"{currentHealth} / {_healthModel.MaxHealth}";
            _healthBar.value = (float)currentHealth / _healthModel.MaxHealth;
        }
    }
}