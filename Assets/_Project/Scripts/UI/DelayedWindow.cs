using System.Collections;
using UnityEngine;

namespace SimpleRunner.UI
{
    public class DelayedWindow : Window
    {
        [SerializeField] private float _delay = 0.5f;
        
        public override void Show()
        {
            StartCoroutine(ShowRoutine());
        }

        public override void Hide()
        {
            WindowObject.SetActive(false);
            Time.timeScale = 1f;
        }

        private IEnumerator ShowRoutine()
        {
            yield return new WaitForSeconds(_delay);
            WindowObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
