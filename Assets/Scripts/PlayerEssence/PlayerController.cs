using System;
using InputEssence;
using UnityEngine.InputSystem;

namespace PlayerEssence
{
    public class PlayerController
    {
        private MainActions _actions;
        private bool _isPressing;
        private IInputHandler _inputHandler;

        private Action<InputAction.CallbackContext> _onStart;
        private Action<InputAction.CallbackContext> _onCanceled;
        
        public PlayerController()
        {
#if UNITY_EDITOR
            _inputHandler = new MouseHandler();
#else
            _inputHandler = new TouchscreenHandler();
#endif
            
            _onStart = context =>
            {
                _isPressing = true;
            };
            _onCanceled = context =>
            {
                _isPressing = false;
                _inputHandler.Clear();
            };
            
            _actions = new MainActions();
            _actions.Player.Click.started += _onStart;
            _actions.Player.Click.canceled += _onCanceled;
            _actions.Enable();
        }

        public void Update()
        {
            _inputHandler.Update();
        }

        public float GetOffset()
        {
            if(_isPressing) return _inputHandler.Swipe();
            return 0;
        }
    }
}