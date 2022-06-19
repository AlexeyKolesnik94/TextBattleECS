using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Systems
{
    internal class AttackSystem : BaseSystem, IEcsRunSystem
    {
        private readonly EcsFilter<BattleUnit> _filter = null;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (var i in _filter)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(i);
                    var damage = Random.Range(8f, 22f);
                    entity.Get<DamageRequest>().Sender = "Мент позорный";
                    entity.Get<DamageRequest>().Value = damage;
                }

                _world.NewEntity().Get<Turn>();
            }
        }
    }
}