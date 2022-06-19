using Components;
using Leopotam.Ecs;

namespace Systems
{
    internal class DestroyEntitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyRequest> _filter = null;
        public void Run()
        {
            foreach (var i in _filter)
            {
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}