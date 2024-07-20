using UnityEngine;
using System;
using Zenject;

namespace Model
{
    public sealed class ShieldModel : MonoBehaviour
    {
        [Inject] private TurnManager _turnManager;
        private int _currentShieldCharges;

        public Action<int> ShieldChargesUpdated;

        private void Awake()
        {
            _turnManager.RoundStarted += ClearAllShieldCharges;
            _turnManager.BattleEnded += ClearAllShieldCharges;
        }

        private void ClearAllShieldCharges() => SetShieldCharges(0);

        public void AddShiled(int shieldCharges)
        {
            shieldCharges = ClampShieldCharges(shieldCharges);

            SetShieldCharges(_currentShieldCharges + shieldCharges);
        }

        private int ClampShieldCharges(int value)
        {
            if (value < 0) value = 0;
            return value;
        }

        public bool TryToBlockDamage(ref int damage)
        {
            if (_currentShieldCharges >= damage)
            {
                SetShieldCharges(_currentShieldCharges - damage);

                damage = 0;

                return true;
            }
            else 
            {
                damage -= _currentShieldCharges;

                SetShieldCharges(0);

                return false;
            }
        }

        private void SetShieldCharges(int value)
        {
            _currentShieldCharges = value;

            ShieldChargesUpdated.Invoke(_currentShieldCharges);
        }
    }
}