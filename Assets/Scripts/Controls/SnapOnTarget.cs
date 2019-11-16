using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapOnTarget : MonoBehaviour
{
    [SerializeField]
    private Transform Target;

    [SerializeField]
    private Vector3 PositionOffset;

    [SerializeField]
    private Vector3 RotationOffset;

    private void Awake()
    {
        SnapToPosition();
        LookAtTargetWithOffset();
    }

    private void Update()
    {
        SnapToPosition();
        LookAtTargetWithOffset();
    }

    private void SnapToPosition()
    {
        transform.position = Target.position + PositionOffset;
    }

    private void LookAtTargetWithOffset()
    {
        transform.LookAt(Target);
        transform.Rotate(RotationOffset);
    }
}
