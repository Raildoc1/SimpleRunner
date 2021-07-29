using System;
using UnityEngine;

namespace SimpleRunner.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private bool _isDead = false;
        public bool IsDead => _isDead;

        public event Action OnPlayerDie;
        
        public void Die()
        {
            _isDead = true;
            OnPlayerDie?.Invoke();
        }
    }
}