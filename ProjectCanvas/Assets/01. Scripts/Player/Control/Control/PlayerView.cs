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

        currentRotation.x += ReverseX ? mouseDelta.y : -mouseDelta.y;
        currentRotation.y += ReverseY ? mouseDelta.x : -mouseDelta.x;

        currentRotation.x = Mathf.Clamp(currentRotation.x, ClampRotateValue.x, ClampRotateValue.y);

        camParent.rotation = Quaternion.Euler(currentRotation);
    }
}
