using UnityEngine;

namespace SimpleRunner.Player
{
    public class PlayerInputAdapter : MonoBehaviour
    {
        private Vector3 _desiredInputDirection = Vector3.zero;
        
        [SerializeField] private PlayerMover _mover;
        [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
        
        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");

            _desiredInputDirection.x = horizontal;
            _desiredInputDirection.y = 0f;
            _desiredInputDirection.z = 1f;
            _desiredInputDirection.Normalize();

            _mover?.Move(_desiredInputDirection);

            if (Input.GetKeyDown(_jumpKey))
            {
                _mover?.Jump();
            }
        }
    }
}
