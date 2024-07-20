using UnityEngine;
using System;

namespace Model
{
    [RequireComponent(typeof(ShieldModel))]

    public sealed class HealthModel : MonoBehaviour
    {
        private ShieldModel _shieldModel;
        private int _maxHealth;
        private int _currentHealth;

        public Action<int> HealthUpdated;
        public Action Died;

        public int MaxHealth => _maxHealth;

        private void Awake()
        {
            _shieldModel = GetComponent<ShieldModel>();
        }

        public void SetMaxHealth(int value)
        {
            _maxHealth = value;
            _currentHealth = _maxHealth;
            HealthUpdated.Invoke(_currentHealth);
        }

        #region TakeDamage
        public void TakeDamage(int damage)
        {
            damage = ClampDamage(damage);

            if (_shieldModel.TryToBlockDamage(ref damage)) return;

            DecreaseCurrentHealth(damage);    
        }
        
        private int ClampDamage(int initialDamage)
        {
            if (initialDamage < 0) initialDamage = 0;
            return initialDamage;
        }

        private void DecreaseCurrentHealth(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - value, 0, _maxHealth);
            HealthUpdated.Invoke(_currentHealth);

            if (_currentHealth == 0) Die();
        }
        
        private void Die() => Died.Invoke();
        #endregion

        #region Heal
        public void Heal(int healAmount)
        {
            healAmount = ClampHeal(healAmount);
            IncreaseCurrentHealth(healAmount);
        }

        private void IncreaseCurrentHealth(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
            HealthUpdated.Invoke(_currentHealth);
        }

        private int ClampHeal(int initialHeal)
        {
            initialHeal = Mathf.Clamp(initialHeal, 0, _maxHealth - _currentHealth);
            return initialHeal;
        }
        #endregion
    }
}