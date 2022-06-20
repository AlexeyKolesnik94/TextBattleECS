using Components;
using Leopotam.Ecs;
using Services;

namespace Systems
{
    internal class StoneSkinSystem : BaseSystem, IEcsRunSystem
    {
        private readonly EcsFilter<DamageRequest, StoneSkin> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damageRequest = ref _filter.Get1(i);
                ref var stoneSkin = ref _filter.Get2(i);

                float percent = stoneSkin.AbilityValue / 100;
                float resistanceValue = damageRequest.Value * percent;
                damageRequest.Value -= resistanceValue;
                
                _world.SendMessage($"{resistanceValue} урона поглощено");
            }
        }
    }
}