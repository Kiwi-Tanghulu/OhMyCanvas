using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 checkSize;
    [SerializeField] private Vector3 checkOffset;
    private Collider[] result;

    private void Awake()
    {
        result = new Collider[1];
    }

    public bool IsGround()
    {
        Array.Clear(result, 0, result.Length);
        
        Physics.OverlapBoxNonAlloc(transform.position + checkOffset,
            checkOffset * 0.5f, result, Quaternion.identity, groundLayer);
        Debug.Log(result[0]);

        return result[0] != null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + checkOffset, checkSize);
    }
#endif
}
