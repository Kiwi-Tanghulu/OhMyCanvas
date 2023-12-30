using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerComponent : NetworkBehaviour
{
    protected PlayerController controller;

    public virtual void InitCompo(PlayerController controller)
    {
        this.controller = controller;
    }

    public virtual void UpdateCompo()
    {
        if (!IsOwner)
            return;
    }
}
