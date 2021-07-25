using UnityEngine;

using System;

/// <summary>
/// Startup and run systems
/// </summary>
public class StartupEcsSystems : MonoBehaviour
{
    [SerializeField] private EcsSystemWrapper[] awake;
    [SerializeField] private EcsSystemWrapper[] start;
    [SerializeField] private EcsSystemWrapper[] update;
    [SerializeField] private EcsSystemWrapper[] fixedUpdate;

    //private EcsWorld _world;

    //private EcsSystems _awake;
    //private EcsSystems _start;
    //private EcsSystems _update;
    //private EcsSystems _fixedUpdate;

    private void Awake()
    {
        //_world = new EcsWorld();

        AddSystemsToExecutionGroup();

        Init();
    }

    private void Start()
    {
        //_start.Init();
    }

    private void Update()
    {
        //_update.Run();
    }

    private void FixedUpdate()
    {
        //_fixedUpdate.Run();
    }

    private void OnDestroy()
    {
        //_awake.Destroy();
        //_start.Destroy();
        //_update.Destroy();

        //_world.Destroy();
    }

    private void Init()
    {
        //_awake.Init();
        //_update.Init();
        //_fixedUpdate.Init();
    }

    private void AddSystemsToExecutionGroup()
    {
        //AddSystemsToExecutionGroup(ref _awake, awake);
        //AddSystemsToExecutionGroup(ref _start, start);
        //AddSystemsToExecutionGroup(ref _update, update);
        //AddSystemsToExecutionGroup(ref _fixedUpdate, fixedUpdate);
    }

    //private void AddSystemsToExecutionGroup(ref EcsSystems group, EcsSystemWrapper[] systems)
    //{
    //    group = new EcsSystems(_world).ConvertScene();

    //    foreach (EcsSystemWrapper system in systems)
    //    {
    //        group = group.Add(system);
    //    }
    //}
}
