using Components;
using Leopotam.Ecs;
using Services;

namespace Systems
{
    internal class BlockShieldSystem : BaseSystem, IEcsRunSystem
    {
        private readonly EcsFilter<DamageRequest, BlockShieldAbility> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damageRequest = ref _filter.Get1(i);
                ref var ability = ref _filter.Get2(i);

                if (ability.ChanceBlock.Roll100())
                {
                    float percent = ability.ChanceBlock / 100f;
                    float blockValue = damageRequest.Value * percent;
                    damageRequest.Value -= blockValue;
                    
                    _world.SendMessage($"{blockValue} урона заблакированно");
                }
            }
        }
    }
}