using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveState : PlayerState
{
    private PlayerAnimation anim;
    private InputReader inputReader;
    private PlayerMovement movement;

    public override void InitState(PlayerController _controller, PlayerStateType type)
    {
        base.InitState(_controller, type);

        anim = controller.Anim;
        inputReader = controller.InputReader;
        movement = controller.Movement;
    }

    public override void EnterState()
    {
        if (IsOwner)
        {
            anim.SetBool(StateType.ToString(), true);
            inputReader.LClick_Event += AttackHandle;
        }
    }

    public override void ExitState()
    {
        if (IsOwner)
        {
            movement.SetMoveDir(Vector2.zero);
            anim.SetBool(StateType.ToString(), false);
            inputReader.LClick_Event -= AttackHandle;
        }
    }

        

    public override void UpdateState()
    {
        if (IsOwner)
        {
            IdleHandle();
            movement.SetMoveDir(inputReader.MoveInputValue);
        }
    }

    private void IdleHandle()
    {
        if (inputReader.MoveInputValue == Vector2.zero)
            controller.ChangeState(PlayerStateType.Idle);
    }

    private void AttackHandle()
    {
        controller.ChangeState(PlayerStateType.Attack);
    }
}