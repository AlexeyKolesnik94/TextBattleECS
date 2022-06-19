using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Systems
{
    internal class SecondChanceAbilitySystem : BaseSystem, IEcsRunSystem
    {
        private readonly EcsFilter<DamageRequest, SecondChanceAbility, BattleUnit> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damageRequest = ref _filter.Get1(i);
                ref var secondChanceAbility = ref _filter.Get2(i);
                ref var unit = ref _filter.Get3(i);

                float restoreLife = 100f;

                if (unit.Health - damageRequest.Value <= 0)
                {
                    if (secondChanceAbility.ChanceValue.Roll100())
                    {
                        unit.Health = restoreLife;
                        _world.SendMessage($"{unit.Name} получил второй шанс! Его жизни востановлены на {restoreLife}");
                    }
                }
                
            }
        }
    }
}