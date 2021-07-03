using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leopotam.Ecs;
using Voody.UniLeo;

public class StartupEcsSystems : MonoBehaviour
{
    [SerializeField] private MovementInput input;

    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {        
        _world = new EcsWorld();

        _systems = new EcsSystems(_world)
            .ConvertScene()
            .Add(new WalkingSystem())
            .Add(new WalkInputSystem(input));

        _systems.Init();
    }

    private void Update()
    {        
        _systems.Run();
    }

    private void OnDestroy()
    {        
        _systems.Destroy();        
        _world.Destroy();
    }
}
