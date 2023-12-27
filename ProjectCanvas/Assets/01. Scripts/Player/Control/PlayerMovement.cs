using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 50f;
    [SerializeField] private bool applyGravity = true;
    private Vector2 moveDir;
    private float verticalVelocity;
    private float gravityScale = -9.81f;

    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

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

    public bool IsGround()
    {
        return cc.isGrounded;
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(
            moveDir.x * moveSpeed,
            verticalVelocity,
            moveDir.y * moveSpeed) * Time.deltaTime;

        cc.Move(moveVector);
    }

    private void Rotate()
    {

    }

    private void Gravity()
    {
        if(!applyGravity) 
            return;

        if(IsGround())
        {
            verticalVelocity = 0f;
            verticalVelocity -= gravityScale * 0.3f * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= gravityScale * Time.deltaTime;
        }
    }
}
