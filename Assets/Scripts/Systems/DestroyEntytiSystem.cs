using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class DestroyEntitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyRequest> _filter = null;
        private readonly EcsFilter<Component<GameObject>, DestroyRequest> _filterPrefabs = null;
        public void Run()
        {
            foreach (var i in _filterPrefabs)
            {
                ref var gameObj = ref _filterPrefabs.Get1(i);
                Object.Destroy(gameObj.Value);
            }
            
            foreach (var i in _filter)
            {
                ref var request = ref _filter.Get1(i);
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}