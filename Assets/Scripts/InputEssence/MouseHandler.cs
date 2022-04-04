using UnityEngine;
using UnityEngine.InputSystem;

namespace InputEssence
{
    public class MouseHandler : IInputHandler
    {
        private Vector3 _mousePosition;
        private Vector3 _lastMousePosition;

        public void Update()
        {
            _lastMousePosition = _mousePosition;
            _mousePosition = Mouse.current.position.ReadValue();
        }
        
        public float Swipe()
        {
            return ((_mousePosition - _lastMousePosition).x/Screen.width);
        }

        public void Clear()
        {
            
        }
    }
}