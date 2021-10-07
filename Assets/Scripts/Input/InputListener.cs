using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

namespace BlueOakBridge
{
    public abstract class InputListener : MonoBehaviour
    {
        [FoldoutGroup("InputListener"), ShowInInspector, ReadOnly] public abstract int Priority { get; }
        [FoldoutGroup("InputListener"), ShowInInspector, ReadOnly] public bool AreEventsRegistered { get; private set; } = false;

        protected virtual void OnEnable() => RegisterEvents();

        protected virtual void OnDisable() => DeregisterEvents();

        public virtual void RegisterEvents()
        {
            if (AreEventsRegistered) return;

            GameInput.OnMoveEvent += OnMoveInput;
            GameInput.OnInteractEvent += OnInteractInput;
            GameInput.OnConfirmEvent += OnConfirmInput;
            GameInput.OnCancelEvent += OnCancelInput;
            GameInput.OnNavigateLeftEvent += OnNavigationLeftInput;
            GameInput.OnNavigateRightEvent += OnNavigationRightInput;
            GameInput.OnPageUpEvent += OnPageUpInput;
            GameInput.OnPageDownEvent += OnPageDownInput;

            AreEventsRegistered = true;
        }

        public virtual void DeregisterEvents()
        {
            if (!AreEventsRegistered) return;

            GameInput.OnMoveEvent -= OnMoveInput;
            GameInput.OnInteractEvent -= OnInteractInput;
            GameInput.OnConfirmEvent -= OnConfirmInput;
            GameInput.OnCancelEvent -= OnCancelInput;
            GameInput.OnNavigateLeftEvent -= OnNavigationLeftInput;
            GameInput.OnNavigateRightEvent -= OnNavigationRightInput;
            GameInput.OnPageUpEvent -= OnPageUpInput;
            GameInput.OnPageDownEvent -= OnPageDownInput;

            AreEventsRegistered = false;
        }

        public virtual void OnMoveInput(InputAction.CallbackContext ctx) { }
        public virtual void OnInteractInput(InputAction.CallbackContext ctx) { }
        public virtual void OnConfirmInput(InputAction.CallbackContext ctx) { }
        public virtual void OnCancelInput(InputAction.CallbackContext ctx) { }
        public virtual void OnNavigationLeftInput(InputAction.CallbackContext ctx) { }
        public virtual void OnNavigationRightInput(InputAction.CallbackContext ctx) { }
        public virtual void OnPageUpInput(InputAction.CallbackContext ctx) { }
        public virtual void OnPageDownInput(InputAction.CallbackContext ctx) { }
    }
}
