using Components;
using Leopotam.Ecs;
using Services;

namespace Systems
{
    internal class DamageSystem : BaseSystem, IEcsRunSystem
    {
        private readonly EcsFilter<BattleUnit, DamageRequest> _filter = null;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var request = ref _filter.Get2(i);
                unit.Health -= request.Value;
               
                if (unit.Health >= 0)
                {
                    _world.SendMessage($"Противник {request.Sender} нанес {unit.Name} урон {request.Value}." +
                                       $" У {unit.Name} осталось {unit.Health} здоровья");
                } else
                {
                    ref var entity = ref _filter.GetEntity(i);
                    entity.Get<DestroyRequest>();
                    
                    _world.SendMessage($"{unit.Name} пал смертью храбрых! Алкоголиков...");
                    unit.Health = 0;
                }
            }
        }
    }
}