using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveState : PlayerState
{
    public override void EnterState()
    {
        controller.Anim.SetAnimBoolProperty(StateType.ToString(), true);
        controller.InputReader.LClick_Event += AttackHandle;
    }

    public override void ExitState()
    {
        controller.Movement.SetMoveDir(Vector2.zero);
        controller.Anim.SetAnimBoolProperty(StateType.ToString(), false);
        controller.InputReader.LClick_Event -= AttackHandle;
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

    private void AttackHandle()
    {
        controller.ChangeState(PlayerStateType.Attack);
    }
}