using SimpleRunner.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleRunner.Core
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private GameObject _loseWindow;
        [SerializeField] private GameObject _winWindow;
        [SerializeField] private GameObject _pauseWindow;
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            if (!_playerHealth)
            {
                Debug.LogError("PlayerHeath not assigned!");
                enabled = false;
                return;
            }

            _playerHealth.OnPlayerDie += OnPlayerDie;
        }

        private void OnDisable()
        {
            _playerHealth.OnPlayerDie -= OnPlayerDie;
        }

        private void OnPlayerDie()
        {
            Time.timeScale = 0f;
            _loseWindow.SetActive(true);
        }

        public void Win()
        {
            Time.timeScale = 0f;
            _winWindow.SetActive(true);
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            _pauseWindow.SetActive(true);
        }

        public void UnPause()
        {
            Time.timeScale = 1f;
            _pauseWindow.SetActive(false);
        }
        
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            _loseWindow.SetActive(false);
            _winWindow.SetActive(false);
        }
    }
}