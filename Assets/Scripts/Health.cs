using System;
using UnityEngine;

namespace RainbowCube
{
    public class Health : MonoBehaviour
    {
        public Action OnDead;
        [SerializeField] private float _amount = 100;
        [SerializeField] private float _maxAmount = 100;
        [SerializeField] private float _deadAmount = 0;

        private void Awake()
        {
            _amount = Mathf.Clamp(_amount, _deadAmount, _maxAmount);
        }

        public void Heal(float value)
        {
            _amount = Mathf.Clamp(_amount + value, _deadAmount, _maxAmount);
        }
        
        public void Damage(float value)
        {
            _amount = Mathf.Clamp(_amount - value, _deadAmount, _maxAmount);
            
            if(_amount <= _deadAmount)
                OnDead?.Invoke();
        }
    }
}