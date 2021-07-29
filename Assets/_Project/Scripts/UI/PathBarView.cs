using SimpleRunner.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleRunner.UI
{
    public class PathBarView : MonoBehaviour
    {
        [SerializeField] private DistanceCounter _distanceCounter;
        [SerializeField] private Image _fill;
        
        private void OnEnable()
        {
            if (!_distanceCounter)
            {
                enabled = false;
            }
        }

        private void Update()
        {
            if (_fill)
            {
                _fill.fillAmount = 1f - _distanceCounter.RemainingPathPercentage;
            }
        }
    }
}
