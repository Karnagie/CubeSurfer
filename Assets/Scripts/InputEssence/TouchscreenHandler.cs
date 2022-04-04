using UnityEngine;
using UnityEngine.InputSystem;

namespace InputEssence
{
    public class TouchscreenHandler : IInputHandler
    {
        private Vector3 _touchPosition;
        private Vector3 _lastTouchPosition;
        private bool _isCleared;

        public void Update()
        {
            _lastTouchPosition = _touchPosition;
            _touchPosition = Touchscreen.current.position.ReadValue();
        }
        
        public float Swipe()
        {
            if (_isCleared)
            {
                _lastTouchPosition = _touchPosition;
                _isCleared = false;
            }
            return ((_touchPosition - _lastTouchPosition).x/Screen.width);
        }

        public void Clear()
        {
            _isCleared = true;
        }
    }
}