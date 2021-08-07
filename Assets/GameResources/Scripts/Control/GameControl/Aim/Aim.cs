using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[GenerateAuthoringComponent]
public struct Aim : IComponentData
{
    [Range(0, Mathf.PI)]
    public float speed;

    [HideInInspector]
    public Vector3 direction;
}
