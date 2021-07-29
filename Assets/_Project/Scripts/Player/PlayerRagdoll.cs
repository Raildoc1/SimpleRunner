using UnityEngine;

namespace SimpleRunner.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(Animator))]
    public class PlayerRagdoll : MonoBehaviour
    {
        private CharacterController _characterController;
        private PlayerHealth _playerHealth;
        private Animator _animator;
        
        private readonly string _obstacleTag = "Obstacle";

        private void OnEnable()
        {
            if (!_playerHealth)
            {
                return;
            }

            _playerHealth.OnDie += TurnOnRagdoll;
        }

        private void OnDisable()
        {
            if (!_playerHealth)
            {
                return;
            }

            _playerHealth.OnDie -= TurnOnRagdoll;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerHealth = GetComponent<PlayerHealth>();
            _animator = GetComponent<Animator>();
        }

        private void TurnOnRagdoll()
        {
            if (_animator != null)
            {
                _animator.enabled = false;
            }
        
            _characterController.enabled = false;
        }
    }
}