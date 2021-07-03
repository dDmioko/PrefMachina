using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leopotam.Ecs;
using Voody.UniLeo;

[Serializable]
public struct Walk
{
    public Transform transform;

    public Rigidbody body;

    public float speed;

    [HideInInspector]
    public Vector3 velocity;
}