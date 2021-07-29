using UnityEngine;

namespace SimpleRunner.View
{
    public class ViewRotater : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        private void Update()
        {
            var rotation = transform.rotation.eulerAngles;
            rotation.y += _speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}