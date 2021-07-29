using UnityEngine;

namespace SimpleRunner.UI
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] protected GameObject WindowObject;
        
        public abstract void Show();
        public abstract void Hide();
    }
}