using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private PlayerMovement movement;
    private PlayerAttack atk;
    private InputReader inputReader;

    public override void InitState(PlayerController _controller, PlayerStateType type)
    {
        base.InitState(_controller, type);

        movement = controller.Movement;
        atk = controller.Attack;
        inputReader = controller.InputReader;
    }

    public override void EnterState()
    {
        if (IsOwner)
        {
            movement.SetMoveDir(Vector2.zero);
            inputReader.LClick_Event += AttackHandle;
        }
    }

    public override void ExitState()
    {
        if (IsOwner)
        {
            inputReader.LClick_Event -= AttackHandle;
        }
    }

    public override void UpdateState()
    {
        if (IsOwner)
        {
            MoveHandle();
        }
    }

    private void MoveHandle()
    {
        if (inputReader.MoveInputValue != Vector2.zero)
            controller.ChangeState(PlayerStateType.Move);
    }

    private void AttackHandle()
    {
        if(!atk.IsAttack)
            controller.ChangeState(PlayerStateType.Attack);
    }
}
