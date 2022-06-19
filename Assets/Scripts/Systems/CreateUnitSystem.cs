using Components;
using Leopotam.Ecs;
using Services;
using Unity.VisualScripting;
using UnityEngine;

namespace Systems
{
    internal class CreateUnitSystem : BaseSystem, IEcsInitSystem
    {
        private Prefabs _prefab;
        
        public void Init()
        {
            CreateOrc("Петрович");
            CreateElf("Афанасий");
        }

        private void CreateOrc(string name)
        {
            EcsEntity entity = _world.NewEntity();
            entity.Get<Component<GameObject>>().Value = Object.Instantiate(_prefab.OrcPrefab);
            ref var battleUnit = ref entity.Get<BattleUnit>();
            battleUnit.Name = "орк " + name;
            battleUnit.Health = 120f;

            entity.Get<Component<GameObject>>().Value.name = battleUnit.Name;
            
            ref var blockAbility = ref entity.Get<BlockShieldAbility>();
            blockAbility.AbilityName = "Грязная фуфайка";
            blockAbility.ChanceBlock = 20f;
            blockAbility.BlockValue = 30f;

            ref var secondChanceAbility = ref entity.Get<SecondChanceAbility>();
            secondChanceAbility.AbilityName = "Выжить любой ценой!";
            secondChanceAbility.ChanceValue = 10f;
            
            _world.SendMessage($"Юнит {battleUnit.Name} создан сщ здоровьем {battleUnit.Health}!");
            _world.SendMessage($"Со спобосбностью {blockAbility.AbilityName}");
            _world.SendMessage($"Со спобосбностью {secondChanceAbility.AbilityName}");
        }

        private void CreateElf(string name)
        {
            EcsEntity entity = _world.NewEntity();
            entity.Get<Component<GameObject>>().Value = Object.Instantiate(_prefab.ElfPrefab);
            ref var battleUnit = ref entity.Get<BattleUnit>();
            battleUnit.Name = "эльф " + name;
            battleUnit.Health = 80f;
            
            entity.Get<Component<GameObject>>().Value.name = battleUnit.Name;

            ref var healAbility = ref entity.Get<Healer>();
            healAbility.NameAbility = "Лечение";
            healAbility.MinHealValue = 3f;
            healAbility.MaxHealValue = 10f;

            _world.SendMessage($"Юнит {battleUnit.Name} создан сщ здоровьем {battleUnit.Health}!");
        }
    }
}