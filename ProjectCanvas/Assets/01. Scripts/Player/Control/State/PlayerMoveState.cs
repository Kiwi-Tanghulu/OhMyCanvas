using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveState : PlayerState
{
    public override void EnterState()
    {
        controller.InputReader.Move_Input += IdleHandle;
        controller.InputReader.Move_Input += controller.Movement.SetMoveDir;
    }

    public override void ExitState()
    {
        controller.InputReader.Move_Input -= IdleHandle;
        controller.InputReader.Move_Input -= controller.Movement.SetMoveDir;
        controller.Movement.SetMoveDir(Vector2.zero);
    }

    public override void UpdateState()
    {

    }

    private void IdleHandle(Vector2 input)
    {
        if (input == Vector2.zero)
            controller.ChangeState(PlayerStateType.Idle);
    }
}
