using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    internal class AttackSystem : BaseSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ClickEvent> _clickEventsFilter = null;
        private GameUI _gameUI;
        

        public void Run()
        {
            foreach (var i in _clickEventsFilter)
            {
                ref EcsEntity entity = ref _clickEventsFilter.GetEntity(i);
                var damage = Random.Range(8f, 22f);
                entity.Get<DamageRequest>().Sender = "Мент позорный";
                entity.Get<DamageRequest>().Value = damage;
            }
        }
    }
}