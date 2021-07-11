using System;
using UnityEngine;

[Serializable]
public struct Walk
{
    public Transform transform;

    public Rigidbody body;

    public float speed;

    [HideInInspector]
    public Vector3 velocity;
}