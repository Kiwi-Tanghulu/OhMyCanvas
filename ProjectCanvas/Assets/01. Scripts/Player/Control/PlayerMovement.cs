using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 50f;
    private Vector2 moveDir;

    private Rigidbody rb;

    private void Update()
    {
        if (!IsOwner)
            return;

        Move();
        Rotate();
    }

    public void SetMoveDir(Vector2 dir)
    {
        moveDir = dir;  
    }

    private void Move()
    {
        rb.velocity = moveDir * moveSpeed;
    }

    private void Rotate()
    {

    }
}
