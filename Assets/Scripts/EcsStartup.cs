using Components;
using Leopotam.Ecs;
using Services;
using Systems;
using UnityEngine;

sealed class EcsStartup : MonoBehaviour
{
    public GameUI GameUI;
    public Prefabs Prefabs;
    
    EcsWorld _world;
    EcsSystems _systems;

    void Start () {
        // void can be switched to IEnumerator for support coroutines.
            
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
            
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif

        _systems
            .Add(new CreateUnitSystem())
            .Add(new AttackSystem())
            
            .Add(new BlockShieldSystem())
            .Add(new DamageSystem())
            .Add(new HealSystem())
            .Add(new SecondChanceAbilitySystem())
            .Add(new MessageSystem())
            .Add(new DestroyEntitySystem())
            
            .OneFrame<MessageRequest>()
            .OneFrame<ClickEvent>()
            .OneFrame<DamageRequest>()
            .OneFrame<Turn>()
                
            // inject service instances here (order doesn't important), for example:
            .Inject (GameUI)
            .Inject(Prefabs)
            // .Inject (new NavMeshSupport ())
            .Init ();
    }

    void Update () {
        _systems?.Run ();
    }

    void OnDestroy () {
        if (_systems != null) {
            _systems.Destroy ();
            _systems = null;
            _world.Destroy ();
            _world = null;
        }
    }
}