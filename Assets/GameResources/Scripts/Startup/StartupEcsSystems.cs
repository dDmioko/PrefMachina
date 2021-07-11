using UnityEngine;

using Leopotam.Ecs;
using Voody.UniLeo;

public class StartupEcsSystems : MonoBehaviour
{
    [SerializeField] private WalkInputControl walkInput;
    [SerializeField] private AimInputControl aimInput;
    [SerializeField] private FireInputControl fireInput;

    [Tooltip("In pixels. If projectile fly further - it deactivates")]
    [SerializeField] private float outOfScreenDistance = 50f;

    private EcsWorld _world;
    private EcsSystems _update;
    private EcsSystems _fixedUpdate;

    private void Awake()
    {        
        _world = new EcsWorld();

        _update = new EcsSystems(_world)
            .ConvertScene()
            .Add(new WalkSystem())
            .Add(new WalkInputSystem(walkInput))
            .Add(new AimSystem())
            .Add(new AimInputSystem(aimInput))
            .Add(new FireInputSystem(fireInput))
            .Add(new SubscribeGunsToInputEvent())
            .Add(new DeactivateOnOffScreenSystem(outOfScreenDistance));

        _fixedUpdate = new EcsSystems(_world)
            .ConvertScene()
            .Add(new RotateToDirectionSystem());

        _update.Init();
        _fixedUpdate.Init();
    }

    private void Update()
    {        
        _update.Run();
    }

    private void FixedUpdate()
    {
        _fixedUpdate.Run();
    }

    private void OnDestroy()
    {        
        _update.Destroy();        
        _world.Destroy();
    }
}
