using UnityEngine;

namespace SimpleRunner.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerCollision : MonoBehaviour
    {
        private CharacterController _characterController;
        
        private readonly string _obstacleTag = "Obstacle";

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        // private void OnControllerColliderHit(ControllerColliderHit hit)
        // {
        //     if (hit.gameObject.CompareTag(_obstacleTag))
        //     {
        //         _playerHealth?.Die();
        //         
        //         if (_animator != null)
        //         {
        //             _animator.enabled = false;
        //         }
        //
        //         _characterController.enabled = false;
        //     }
        // }
    }
}