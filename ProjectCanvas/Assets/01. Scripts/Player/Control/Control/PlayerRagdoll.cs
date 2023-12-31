using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : PlayerComponent
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject ragdollObj;

    public void SetRagdoll(bool value)
    {
        playerObj.SetActive(!value);
        ragdollObj.SetActive(value);
    }
}
