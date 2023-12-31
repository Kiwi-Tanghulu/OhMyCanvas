using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStunState : PlayerState
{
    public override void EnterState()
    {
        Debug.Log("stun");
        controller.Ragdoll.ActiveRagdoll(true);
        controller.Ragdoll.EffectRagdoll((Vector3.forward + Vector3.up).normalized, 300);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }
}
