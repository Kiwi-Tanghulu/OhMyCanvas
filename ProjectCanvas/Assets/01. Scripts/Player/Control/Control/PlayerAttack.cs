using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerAttack : PlayerComponent
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackOffset = 1f;

    public bool IsAttack { get; private set; } = false;

    private Coroutine setWeightCo;

    public void DoAttack()
    {
        if (!IsOwner || IsAttack)
            return;

        if (setWeightCo != null)
            controller.Anim.StopCoroutine(setWeightCo);

        controller.Anim.SetLayerWeight("Attack Layer", 1);
        controller.Anim.SetTrigger("Attack");
        IsAttack = true;
    }

    public void EndAttack()
    {
        IsAttack = false;
        controller.Anim.SetLayerWeight("Attack Layer", 1, 0, 0.2f);
        controller.ChangeState(PlayerStateType.Move);
    }

    public void CheckHit()
    {
        if (!IsServer)
            return;

        Collider[] cols = Physics.OverlapSphere(transform.position + transform.forward * attackOffset, attackRange * 0.5f);

        foreach(Collider col in cols)
        {
            if(col.TryGetComponent<IDamageable>(out IDamageable hit))
            {
                if (col.transform == transform)
                    continue;

                hit.OnDamaged();
            }
        }
    }

//#if UNITY_EDITOR
//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position + transform.forward * attackOffset, attackRange * 0.5f);
//    }
//#endif
}
