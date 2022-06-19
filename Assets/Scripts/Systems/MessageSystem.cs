using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Systems
{
    class MessageSystem : BaseSystem, IEcsRunSystem
    {
        private EcsFilter<MessageRequest> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var request = ref _filter.Get1(i);
                Debug.Log(request.Message);
            }
        }
    }
}