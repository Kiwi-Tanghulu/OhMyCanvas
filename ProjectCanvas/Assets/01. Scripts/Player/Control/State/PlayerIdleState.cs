using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public override void EnterState()
    {
        controller.Movement.SetMoveDir(Vector2.zero);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        MoveHandle();
    }

    private void MoveHandle()
    {
        if (controller.InputReader.MoveInputValue != Vector2.zero)
            controller.ChangeState(PlayerStateType.Move);
    }
}
