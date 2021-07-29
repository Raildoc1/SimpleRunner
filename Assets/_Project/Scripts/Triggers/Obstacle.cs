using SimpleRunner.Player;
using UnityEngine;

namespace SimpleRunner.Triggers
{
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.GetComponentInParent<PlayerHealth>()?.Die();
        }
    }
}