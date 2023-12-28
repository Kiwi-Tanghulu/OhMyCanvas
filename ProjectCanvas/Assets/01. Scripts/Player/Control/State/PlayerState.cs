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

        if (!IsOwner)
            return;
    }

    public virtual void EnterState()
    {
        if (!IsOwner)
            return;
    }
    public virtual void UpdateState()
    {
        if (!IsOwner)
            return;
    }
    public virtual void ExitState()
    {
        if (!IsOwner)
            return;
    }
}
