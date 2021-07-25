using System;
using Unity.Entities;

/// <summary>
/// Abstract input control
/// </summary>
public abstract class AbstractInputControl : SystemBase
{
    public event Action Inited;

    protected PlayerActions inputActions;

    protected override void OnCreate()
    {
        base.OnCreate();

        inputActions = new PlayerActions();

        Inited?.Invoke();
    }

    protected override void OnStartRunning()
    {
        base.OnStartRunning();

        if (inputActions is null)
        {
            Inited += ActivateInputActions;

            return;
        }

        ActivateInputActions();
    }

    protected override void OnStopRunning()
    {
        base.OnStopRunning();

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
