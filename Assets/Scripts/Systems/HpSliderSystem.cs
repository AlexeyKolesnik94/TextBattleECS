using Components;
using Leopotam.Ecs;
using Services;

namespace Systems
{
    internal class HpSliderSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BattleUnit, Component<SliderHp>> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var sliderHp = ref _filter.Get2(i).Value;

                sliderHp.Value = unit.Health / unit.MaxHealth;
            }
        }
    }
}