using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public override void EnterState()
    {
        controller.Anim.OnAnimEvent += controller.Attack.CheckHit;
        controller.Anim.AnimEndEvent += controller.Attack.EndAttack;
        controller.Attack.DoAttack();
    }

    public override void ExitState()
    {
        controller.Anim.OnAnimEvent -= controller.Attack.CheckHit;
        controller.Anim.AnimEndEvent -= controller.Attack.EndAttack;
    }

    public override void UpdateState()
    {
        Vector2 moveInput = controller.InputReader.MoveInputValue;

        controller.Movement.SetMoveDir(moveInput);
        controller.Anim.SetAnimBoolProperty("Move", moveInput != Vector2.zero);
    }
}
