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
        if (value)
        {
            CopyTrm(playerObj, ragdollObj);
        }
        else
        {
            transform.position = effectObj.transform.position;
        }
        
        playerObj.gameObject.SetActive(!value);
        ragdollObj.gameObject.SetActive(value);
    }

    public void EffectRagdoll(Vector3 dir, float power)
    {
        effectObj.AddForce(dir * power, ForceMode.Impulse);
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
