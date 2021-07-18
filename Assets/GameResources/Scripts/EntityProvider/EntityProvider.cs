using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityProvider : MonoBehaviour
{
    private EcsEntity entity;
    public EcsEntity Entity => entity;

    public void SetEntity(EcsEntity entity)
    {
        this.entity = entity;        
    }
}
