using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 50f;
    [SerializeField] private bool applyGravity = true;
    private Vector2 moveDir;
    private float verticalVelocity;
    private float gravityScale = -9.81f;

    private void Update()
    {
        if (!IsOwner)
            return;

        Gravity();
        Move();
        Rotate();
    }

    public void SetMoveDir(Vector2 dir)
    {
        moveDir = dir;  
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(
            moveDir.x * moveSpeed,
            verticalVelocity,
            moveDir.y * moveSpeed) * Time.deltaTime;

        transform.Translate(moveVector);
    }

    private void Rotate()
    {

    }

    private void Gravity()
    {
        if(!applyGravity) 
            return;

        if(groundChecker.IsGround())
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += gravityScale * Time.deltaTime;
        }
    }
}
