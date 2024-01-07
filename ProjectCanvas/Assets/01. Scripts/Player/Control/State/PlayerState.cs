using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public abstract class PlayerState : NetworkBehaviour
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
