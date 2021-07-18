using System;
using UnityEngine;

[Serializable]
public struct RotateToDirection
{
    public GameObject gameObject;
    public Transform transform;

    [HideInInspector]
    public Vector3 previousPosition;
}
