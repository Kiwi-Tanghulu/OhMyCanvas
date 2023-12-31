using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : PlayerComponent
{
    [SerializeField] private Transform playerObj;
    [SerializeField] private Transform ragdollObj;
    [SerializeField] private Rigidbody effectObj;

    public void ActiveRagdoll(bool value)
    {
        CopyTrm(value);
        playerObj.gameObject.SetActive(!value);
        ragdollObj.gameObject.SetActive(value);
    }

    public void EffectRagdoll(Vector3 dir, float power)
    {
        effectObj.AddForce(dir * power, ForceMode.Impulse);
    }

    private void CopyTrm(bool isRagdoll)
    {
        if (isRagdoll)
            CopyTrm(playerObj, ragdollObj);
        else
            CopyTrm(ragdollObj, playerObj);
    }

    private void CopyTrm(Transform from, Transform to)
    {
        for(int i = 0; i < from.childCount; i++)
        {
            if(from.childCount != 0)
                CopyTrm(from.GetChild(i), to.GetChild(i));

            to.GetChild(i).localPosition = from.GetChild(i).localPosition;
            to.GetChild(i).localRotation = from.GetChild(i).localRotation;
        }
    }
}
