using System;
using UnityEngine;

[Serializable]
public struct Aim
{
    public Transform transform;

    [Range(0, Mathf.PI)]
    public float speed;

    [HideInInspector]
    public Vector3 direction;
}
