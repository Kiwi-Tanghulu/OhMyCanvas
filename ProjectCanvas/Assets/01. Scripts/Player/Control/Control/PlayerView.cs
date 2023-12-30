using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : PlayerComponent
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform camParent;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 ClampRotateValue;
    [SerializeField] private bool ReverseX;
    [SerializeField] private bool ReverseY;

    private Vector2 currentRotation = Vector2.zero;
    private Vector2 mouseDelta;

    public Quaternion ForwardRotation => Quaternion.Euler(0f, currentRotation.y, 0f);

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (!IsOwner)
            cam.Priority = 0;
    }

    public override void UpdateCompo()
    {
        base.UpdateCompo();
       
        RotateCamera();
    }

    private void RotateCamera()
    {
        mouseDelta = inputReader.MouseDeltaValue * moveSpeed;

        //회전값 구하기 
        currentRotation.x += ReverseX ? mouseDelta.y : -mouseDelta.y;
        currentRotation.y += ReverseY ? mouseDelta.x : -mouseDelta.x;

        //360도 회전하지 않도록 회전값 제한
        currentRotation.x = Mathf.Clamp(currentRotation.x, ClampRotateValue.x, ClampRotateValue.y);

        //회전
        camParent.rotation = Quaternion.Euler(currentRotation);
    }
}
