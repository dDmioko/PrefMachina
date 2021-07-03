using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leopotam.Ecs;
using Voody.UniLeo;

[Serializable]
public struct Aim
{
    public Transform transform;

    [Range(0, Mathf.PI)]
    public float speed;

    [HideInInspector]
    public Vector3 direction;
}
