using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public override void EnterState()
    {
        controller.InputReader.Move_Input += MoveHandle;
    }

    public override void ExitState()
    {
        controller.InputReader.Move_Input -= MoveHandle;
    }

    public override void UpdateState()
    {

    }

    private void MoveHandle(Vector2 input)
    {
        if (input != Vector2.zero)
            controller.ChangeState(PlayerStateType.Move);
    }
}
