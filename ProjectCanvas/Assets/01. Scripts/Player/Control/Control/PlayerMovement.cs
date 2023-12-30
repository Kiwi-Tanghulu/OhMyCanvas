using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : PlayerComponent
{
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private bool applyGravity = true;

    private Vector3 moveDir;
    private float verticalVelocity;
    private float gravityScale = -9.81f;

    private Tween rotateTween;

    public override void UpdateCompo()
    {
        base.UpdateCompo();

        Gravity();
        Move();
        Rotate();
    }

    public void SetMoveDir(Vector2 dir)
    {
        moveDir = (controller.View.ForwardRotation * new Vector3(dir.x, 0f, dir.y)).normalized; 
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(
            moveDir.x * moveSpeed,
            verticalVelocity,
            moveDir.z * moveSpeed) * Time.deltaTime;

        transform.position += moveVector;
    }

    private void Rotate()
    {
        if (moveDir == Vector3.zero)
            return;

        Quaternion target = Quaternion.Euler(0f, Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg, 0f);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * rotateSpeed);
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

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + moveDir * 5f);
    }
#endif
}
