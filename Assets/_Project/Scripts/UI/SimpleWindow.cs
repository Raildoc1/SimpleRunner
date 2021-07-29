using UnityEngine;

namespace SimpleRunner.UI
{
    public class SimpleWindow : Window
    {
        public override void Show()
        {
            WindowObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public override void Hide()
        {
            WindowObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
