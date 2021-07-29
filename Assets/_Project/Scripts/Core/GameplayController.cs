using System;
using SimpleRunner.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SimpleRunner.Core
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;

        public event Action OnPlayerDie;
        public event Action OnFinishGame;
        public event Action OnGamePaused;

        public UnityEvent UnityOnFinishGame;
        
        private void OnEnable()
        {
            if (!_playerHealth)
            {
                Debug.LogError("PlayerHeath not assigned!");
                enabled = false;
                return;
            }
            
            _playerHealth.OnDie += PlayerDie;
        }

        private void OnDisable()
        {
            _playerHealth.OnDie -= PlayerDie;
        }

        private void PlayerDie()
        {
            OnPlayerDie?.Invoke();
        }

        public void Win()
        {
            OnFinishGame?.Invoke();
            UnityOnFinishGame?.Invoke();
        }

        public void Pause()
        {
            OnGamePaused?.Invoke();
        }
        
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}