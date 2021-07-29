using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRunner.Player
{
    public class PlayerCoinCollector : MonoBehaviour
    {
        private int _coinsAmount = 0;
        public int CoinsAmount => _coinsAmount;

        public void CollectCoin()
        {
            _coinsAmount++;
        }
    }
}
