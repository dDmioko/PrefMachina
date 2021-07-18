using System;
using UnityEngine;

[Serializable]
public struct DeactivateOnOffScreen
{
    public GameObject gameObject;
    public Transform transform;

    [Tooltip("Destroy object when out of screen")]
    public bool isDelete;
}
