using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform camParent;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 ClampRotateValue;
    [SerializeField] private bool ReverseX;
    [SerializeField] private bool ReverseY;

    private Vector2 currentRotation = Vector2.zero;
    private Vector2 mouseDelta;

    private void Update()
    {
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
