using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Systems
{
    internal class HealSystem : BaseSystem, IEcsRunSystem
    {
        private readonly EcsFilter<Turn> _turnFilter = null;
        private readonly EcsFilter<BattleUnit, Healer> _healFilter = null;
        private readonly EcsFilter<BattleUnit> _unitFilter = null;
        
        
        public void Run()
        {
            if (_turnFilter.IsEmpty()) return;
            
            foreach (var i in _healFilter)
            {
                ref var healUnit = ref _healFilter.Get1(i);
                ref var healAbility = ref _healFilter.Get2(i);
                
                float maxHp = int.MaxValue;
                EcsEntity entityForHeal = EcsEntity.Null;
                
                foreach (var j in _unitFilter)
                {
                    ref var unit = ref _unitFilter.Get1(j);
                    if (unit.Health < maxHp)
                    {
                        maxHp = unit.Health;
                        entityForHeal = _unitFilter.GetEntity(j);
                    }
                }

                if (entityForHeal == EcsEntity.Null) continue;
                
                var health = Random.Range(healAbility.MinHealValue, healAbility.MaxHealValue);
                entityForHeal.Get<BattleUnit>().Health += health;
                _world.SendMessage($"{healUnit.Name} полечил {entityForHeal.Get<BattleUnit>().Name} на {health} очков здоровья");
            }
        }
    }
}