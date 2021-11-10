using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Polkawar
{
    [DefaultExecutionOrder(-100)]
    public class GameInput : SingletonMB<GameInput>
    {
        public delegate void OnInput(InputAction.CallbackContext ctx);
        public static event OnInput OnMoveEvent;
        public static event OnInput OnInteractEvent;
        public static event OnInput OnConfirmEvent;
        public static event OnInput OnCancelEvent;
        public static event OnInput OnNavigateLeftEvent;
        public static event OnInput OnNavigateRightEvent;
        public static event OnInput OnPageUpEvent;
        public static event OnInput OnPageDownEvent;

        #region Initialization

        protected PlayerInput _playerInput;

        public static PlayerInput GetPlayerInput => Instance ? (Instance._playerInput ? Instance._playerInput : Instance._playerInput = Instance.GetComponent<PlayerInput>()) : null;

        #endregion Initialization

        #region Input

        public void OnMove(InputAction.CallbackContext ctx)
        {
            //Log.RawData("OnMove");
            OnMoveEvent?.Invoke(ctx);
        }

        public void OnInteract(InputAction.CallbackContext ctx)
        {
            //Log.RawData("OnInteract");
            OnInteractEvent?.Invoke(ctx);
        }

        public void OnConfirm(InputAction.CallbackContext ctx)
        {
            //Log.RawData("OnConfirm");
            OnConfirmEvent?.Invoke(ctx);
        }

        public void OnCancel(InputAction.CallbackContext ctx)
        {
            //Log.RawData("OnCancel");
            OnCancelEvent?.Invoke(ctx);
        }

        public void NavigateLeft(InputAction.CallbackContext ctx)
        {
            //Debug.Log("NavigateLeft");
            OnNavigateLeftEvent?.Invoke(ctx);
        }

        public void NavigateRight(InputAction.CallbackContext ctx)
        {
            //Debug.Log("NavigateRight");
            OnNavigateRightEvent?.Invoke(ctx);
        }

        public void PageUp(InputAction.CallbackContext ctx)
        {
            //Debug.Log("NavigateRight");
            OnPageUpEvent?.Invoke(ctx);
        }

        public void PageDown(InputAction.CallbackContext ctx)
        {
            //Debug.Log("NavigateRight");
            OnPageDownEvent?.Invoke(ctx);
        }

        #endregion

        [Button]
        private void ChangePlayerInputToUI()
        {
            GetPlayerInput.SwitchCurrentActionMap("MenuControls");
        }
    }
    
}

