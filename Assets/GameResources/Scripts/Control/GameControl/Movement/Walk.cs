using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct Walk : IComponentData
{
    public float speed;

    [HideInInspector]
    public Vector3 direction;
}