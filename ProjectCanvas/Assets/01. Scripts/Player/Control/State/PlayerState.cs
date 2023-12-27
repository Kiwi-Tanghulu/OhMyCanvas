using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public PlayerStateType StateType { get; private set; }
    protected PlayerController controller;

    public virtual void InitState(PlayerController _controller, PlayerStateType type)
    {
        controller = _controller;
        StateType = type;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
