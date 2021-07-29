using SimpleRunner.Core;
using UnityEngine;

namespace SimpleRunner.UI
{
    public class UiManager : MonoBehaviour
    {
        private GameplayController _gameplayController;

        [SerializeField] private Window _loseWindow;
        [SerializeField] private Window _winWindow;
        [SerializeField] private Window _pauseWindow;

        private void OnEnable()
        {
            _gameplayController = FindObjectOfType<GameplayController>();
            _gameplayController.OnPlayerDie += Lose;
            _gameplayController.OnFinishGame += Win;
            _gameplayController.OnGamePaused += Pause;
        }

        private void OnDisable()
        {
            _gameplayController.OnPlayerDie -= Lose;
            _gameplayController.OnFinishGame -= Win;
            _gameplayController.OnGamePaused -= Pause;
        }

        private void Pause()
        {
            _pauseWindow.Show();
        }

        private void Win()
        {
            _winWindow.Show();
        }

        private void Lose()
        {
            _loseWindow.Show();
        }
    }
}
