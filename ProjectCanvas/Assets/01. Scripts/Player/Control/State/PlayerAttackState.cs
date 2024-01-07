using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private PlayerAnimation anim;
    private PlayerAttack atk;
    private PlayerMovement movement;
    private InputReader inputReader;

    private Vector2 moveInput;

    public override void InitState(PlayerController _controller, PlayerStateType type)
    {
        base.InitState(_controller, type);

        anim = controller.Anim;
        atk = controller.Attack;
        movement = controller.Movement;
        inputReader = controller.InputReader;
        moveInput = Vector2.zero;
    }

    public override void EnterState()
    {
        if(IsServer)
        {
            anim.OnAnimEvent += controller.Attack.CheckHit;
        }

        if (IsOwner)
        {
            atk.DoAttack();
            anim.AnimEndEvent += controller.Attack.EndAttack;
            moveInput = Vector2.zero;
        }
    }

    public override void ExitState()
    {
        if (IsServer)
        {
            anim.OnAnimEvent -= controller.Attack.CheckHit;
        }

        if (IsOwner)
        {
            anim.AnimEndEvent -= controller.Attack.EndAttack;
            moveInput = Vector2.zero;
        }
    }

    public override void UpdateState()
    {
        if (IsOwner)
        {
            moveInput = inputReader.MoveInputValue;
            movement.SetMoveDir(moveInput);
            anim.SetBool("Move", moveInput != Vector2.zero);
        }
    }
}
