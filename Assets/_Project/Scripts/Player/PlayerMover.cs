using System.Collections;
using UnityEngine;

namespace SimpleRunner.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMover : MonoBehaviour
    {
        private CharacterController _characterController;
        private Animator _animator;
        private Vector3 _currentDirection = Vector3.zero;
        private Vector3 _desiredDirection = Vector3.zero;
        private Vector3 _jumpVelocity = Vector3.zero;
        private bool _inJump = false;
        private bool _startJump = false;
        
        private readonly int _inputHorizontalAnimatorParam = Animator.StringToHash("HorizontalSpeed");
        private readonly int _inputVerticalAnimatorParam = Animator.StringToHash("VerticalSpeed");
        private readonly int _jumpAnimatorParam = Animator.StringToHash("InJump");
        
        [SerializeField] private float _acceleration = 2f;
        [SerializeField] private float _speed = 3.5f;
        [SerializeField] private float _minXPosition = -4.8f;
        [SerializeField] private float _maxXPosition = 4.8f;
        [SerializeField] private float _jumpHeight = 1.5f;
        [SerializeField] private float _startJumpTime = .25f;

        private bool InJump
        {
            get => _inJump;
            set
            {
                _inJump = value;
                _animator.SetBool(_jumpAnimatorParam, InJump);
            }
        }
        
        private void OnValidate()
        {
            if (_minXPosition > _maxXPosition)
            {
                _minXPosition = _maxXPosition;
            }
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        public void Move(Vector3 direction)
        {
            _desiredDirection = direction;
        }

        private void Update()
        {
            UpdatePosition();
            ClampPosition();
            UpdateAnimator();

            if (_characterController.isGrounded && !_startJump)
            {
                InJump = false;
            }
        }

        private void UpdatePosition()
        {
            if (InJump)
            {
                _characterController.Move(_jumpVelocity * Time.deltaTime);
                _jumpVelocity.y += Physics.gravity.y * Time.deltaTime;
                return;
            }
            
            _currentDirection = Vector3.MoveTowards(_currentDirection, _desiredDirection, _acceleration * Time.deltaTime);
            _characterController.Move(_currentDirection * (_speed * Time.deltaTime));
            _characterController.Move(Physics.gravity * Time.deltaTime);
        }

        private void ClampPosition()
        {
            var position = transform.position;
            position.x = Mathf.Clamp(position.x, _minXPosition, _maxXPosition);
            transform.position = position;
        }

        private void UpdateAnimator()
        {
            _animator.SetFloat(_inputHorizontalAnimatorParam, _currentDirection.x);
            _animator.SetFloat(_inputVerticalAnimatorParam, _currentDirection.z);
        }

        public void Jump()
        {
            InJump = true;
            StartCoroutine(StartJumpRoutine());
            
            _jumpVelocity.y = Mathf.Sqrt(-_jumpHeight * 2f * Physics.gravity.y);
            _jumpVelocity.z = _speed;
            _jumpVelocity.x = 0f;
        }
        
        private IEnumerator StartJumpRoutine()
        {
            _startJump = true;
            yield return new WaitForSeconds(_startJumpTime);
            _startJump = false;
        }
    }
}