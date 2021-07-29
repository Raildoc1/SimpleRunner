using SimpleRunner.Player;
using UnityEngine;

namespace SimpleRunner.Triggers
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var collector = other.gameObject.GetComponent<PlayerCoinCollector>();

            if (collector)
            {
                collector.CollectCoin();
                gameObject.SetActive(false);
            }
        }
    }
}