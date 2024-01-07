using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
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
    private CharacterController cc;

    public override void InitCompo(PlayerController controller)
    {
        base.InitCompo(controller);

        cc = GetComponent<CharacterController>();
    }

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

        cc.Move(moveVector);
    }

    private void Rotate()
    {
        if (moveDir == Vector3.zero)
            return;

        float angle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    private void Gravity()
    {
        if(!applyGravity) 
            return;

        if(cc.isGrounded)
        {
            verticalVelocity = gravityScale * 0.3f * Time.deltaTime;
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
