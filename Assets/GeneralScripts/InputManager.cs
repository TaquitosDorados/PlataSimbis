using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event StartTouch OnEndTouch;

    public static event Action Tap;
    public static event Action HoldStarted;
    public static event Action HoldEnded;
    #endregion

    private InputActions inputActions;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        inputActions = new InputActions();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void Start()
    {
        inputActions.Touch.FirstContact.started += ctx => StartTouchPrimary(ctx);
        inputActions.Touch.FirstContact.canceled += ctx => EndTouchPrimary(ctx);
        inputActions.Touch.Tap.started += ctx => StartTap(ctx);
        inputActions.Touch.Hold.performed += ctx => StartHold(ctx);
        inputActions.Touch.Hold.canceled += ctx => EndHold(ctx);
    }

    void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
            OnStartTouch(Utility.ScreenToWorld(mainCamera, inputActions.Touch.FirstPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(Utility.ScreenToWorld(mainCamera, inputActions.Touch.FirstPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public Vector2 PrimaryPosition()
    {
        return Utility.ScreenToWorld(mainCamera, inputActions.Touch.FirstPosition.ReadValue<Vector2>());
    }

    void StartTap(InputAction.CallbackContext context)
    {
        Tap?.Invoke();
    }
    void StartHold(InputAction.CallbackContext context)
    {
        HoldStarted?.Invoke();
    }
    void EndHold(InputAction.CallbackContext context)
    {
        HoldEnded?.Invoke();
    }
}
