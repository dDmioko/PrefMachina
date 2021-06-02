using System;
using UnityEngine;

/// <summary>
/// Abstract input control
/// </summary>
public abstract class AbstractInputControl : MonoBehaviour
{
    public event Action Inited;

    protected PlayerActions inputActions;

    protected virtual void Awake()
    {
        inputActions = new PlayerActions();

        Inited?.Invoke();
    }

    protected virtual void OnEnable()
    {
        if (inputActions is null)
        {
            Inited += ActivateInputActions;

            return;
        }

        ActivateInputActions();
    }

    protected virtual void OnDisable()
    {
        Inited -= ActivateInputActions;

        DeactivateInputActions();
    }

    protected virtual void ActivateInputActions()
    {
        inputActions.Main.Enable();

        SubscribeInputActions();
    }

    protected virtual void DeactivateInputActions()
    {
        inputActions.Main.Disable();

        UnsubscribeInputActions();
    }

    protected abstract void SubscribeInputActions();
    protected abstract void UnsubscribeInputActions();
}
