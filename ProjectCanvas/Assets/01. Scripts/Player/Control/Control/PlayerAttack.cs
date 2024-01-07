using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerAttack : PlayerComponent
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackOffset = 1f;
    [SerializeField] private float attackDely = 0.5f;

    public bool IsAttack { get; private set; } = false;
    public bool CanAttack { get; private set; } = true;

    private Coroutine setWeightCo;

    public void DoAttack()
    {
        if (!IsOwner  || !CanAttack)
            return;

        if (setWeightCo != null)
            controller.Anim.StopCoroutine(setWeightCo);

        controller.Anim.SetLayerWeight("Attack Layer", 1);
        controller.Anim.SetTrigger("Attack");
        IsAttack = true;
        CanAttack = false;
    }

    public void EndAttack()
    {
        setWeightCo = controller.Anim.SetLayerWeight("Attack Layer", 1, 0, 0.2f);
        controller.ChangeState(PlayerStateType.Idle);
        IsAttack = false;
        StartCoroutine(AttackDelay());
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

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDely);

        CanAttack = true;
    }

//#if UNITY_EDITOR
//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position + transform.forward * attackOffset, attackRange * 0.5f);
//    }
//#endif
}
