using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStunState : PlayerState
{
    [SerializeField] private float StunTime;
    [SerializeField] private float effectPower = 300f;

    private PlayerRagdoll ragdoll;

    public override void InitState(PlayerController _controller, PlayerStateType type)
    {
        base.InitState(_controller, type);

        ragdoll = controller.Ragdoll;
    }

    public override void EnterState()
    {
        ragdoll.ActiveRagdoll(true);
        ragdoll.EffectRagdoll((Vector3.forward + Vector3.up).normalized, 300f);

        if (IsOwner)
        {
            StartCoroutine(IdleHandle());
        }
    }

    public override void ExitState()
    {
        ragdoll.ActiveRagdoll(false);
    }

    public override void UpdateState()
    {
        
    }

    private IEnumerator IdleHandle()
    {
        yield return new WaitForSeconds(StunTime);

        controller.ChangeState(PlayerStateType.Idle);
    }
}
