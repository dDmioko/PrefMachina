using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
[GenerateAuthoringComponent]
public struct Walk : IComponentData
{
    public float speed;

    [HideInInspector]
    public Vector3 velocity;
}