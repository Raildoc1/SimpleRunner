using UnityEngine;

namespace SimpleRunner.Utils
{
    public class DistanceCounter : MonoBehaviour
    {
        private float _distance = 1f;
        private float _remainDistance = 0f;

        [SerializeField] private Transform _destination;
        
        public float RemainingPathPercentage => Mathf.Clamp01(_remainDistance / _distance);

        private void Start()
        {
            _distance = Vector3.Distance(transform.position, _destination.position);
        }

        private void Update()
        {
            _remainDistance = Vector3.Distance(transform.position, _destination.position);
        }
    }
}
