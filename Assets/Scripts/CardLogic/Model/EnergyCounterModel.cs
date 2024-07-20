using UnityEngine;
using System;
using Zenject;

namespace Model
{
    public sealed class EnergyCounterModel : MonoBehaviour
    {
        [Inject] private TurnManager _turnManager;
        [SerializeField] private int _maxEnergy;
        private int _currentEnergy;

        public Action<int> EnergyUpdated;

        private void Awake()
        {
            _turnManager.RoundStarted += RefillEnergyToFull;
        }

        public bool HasEnoughEnergy(int value)
        {
            return _currentEnergy >= value;
        }

        public void SpendEnergy(int value)
        {
            SetCurrentEnergy(_currentEnergy -= value);
        }

        private void RefillEnergyToFull()
        {
            SetCurrentEnergy(_maxEnergy);
        }

        private void SetCurrentEnergy(int value)
        {
            _currentEnergy = value;

            EnergyUpdated.Invoke(_currentEnergy);
        }
    }
}

