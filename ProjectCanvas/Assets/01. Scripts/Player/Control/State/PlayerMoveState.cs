using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveState : PlayerState
{
    public override void EnterState()
    {

    }

    public override void ExitState()
    {
        controller.Movement.SetMoveDir(Vector2.zero);
    }

    public override void UpdateState()
    {
        IdleHandle();
        controller.Movement.SetMoveDir(controller.InputReader.MoveInputValue);
    }

    private void IdleHandle()
    {
        if (controller.InputReader.MoveInputValue == Vector2.zero)
            controller.ChangeState(PlayerStateType.Idle);
    }
}
