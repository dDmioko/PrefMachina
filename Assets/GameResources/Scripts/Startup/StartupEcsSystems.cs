using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leopotam.Ecs;
using Voody.UniLeo;

public class StartupEcsSystems : MonoBehaviour
{
    [SerializeField] private WalkInputControl walkInput;
    [SerializeField] private AimInputControl aimInput;

    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {        
        _world = new EcsWorld();

        _systems = new EcsSystems(_world)
            .ConvertScene()
            .Add(new WalkSystem())
            .Add(new WalkInputSystem(walkInput))
            .Add(new AimSystem())
            .Add(new AimInputSystem(aimInput));

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
