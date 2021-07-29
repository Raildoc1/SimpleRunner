using SimpleRunner.Core;
using UnityEngine;

namespace SimpleRunner.Triggers
{
    [RequireComponent(typeof(Collider))]
    public class FinishLevelTrigger : MonoBehaviour
    {
        [SerializeField] private GameplayController _gameplayController;
        private void OnTriggerEnter(Collider other)
        {
            _gameplayController?.Win();
        }
    }
}