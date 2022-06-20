using Components;
using Leopotam.Ecs;
using Services;
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
            ref var battleUnit = ref entity.Get<BattleUnit>();
            battleUnit.Name = "орк " + name;
            battleUnit.Health = 120f;

            ref var blockAbility = ref entity.Get<BlockShieldAbility>();
            blockAbility.AbilityName = "Грязная фуфайка";
            blockAbility.ChanceBlock = 20f;
            blockAbility.BlockValue = 30f;

            ref var secondChanceAbility = ref entity.Get<SecondChanceAbility>();
            secondChanceAbility.AbilityName = "Выжить любой ценой!";
            secondChanceAbility.ChanceValue = 10f;

            var gameObj = Object.Instantiate(_prefab.OrcPrefab);
            gameObj.GetComponent<Unit>().Entity = entity;
            
            entity.Get<Component<GameObject>>().Value = gameObj;
            entity.Get<Component<GameObject>>().Value.name = battleUnit.Name;

            _world.SendMessage($"Юнит {battleUnit.Name} создан со здоровьем {battleUnit.Health}!");
            _world.SendMessage($"Со спобосбностью {blockAbility.AbilityName}");
            _world.SendMessage($"Со спобосбностью {secondChanceAbility.AbilityName}");
        }

        private void CreateElf(string name)
        {
            EcsEntity entity = _world.NewEntity();
            ref var battleUnit = ref entity.Get<BattleUnit>();
            battleUnit.Name = "эльф " + name;
            battleUnit.Health = 80f;

            ref var ability = ref entity.Get<Healer>();
            ability.NameAbility = "Лечение";
            ability.MinHealValue = 8f;
            ability.MaxHealValue = 15f;

            var gameObj = Object.Instantiate(_prefab.ElfPrefab);
            gameObj.GetComponent<Unit>().Entity = entity;
            
            entity.Get<Component<GameObject>>().Value = gameObj;
            entity.Get<Component<GameObject>>().Value.name = battleUnit.Name;

            _world.SendMessage($"Юнит {battleUnit.Name} создан со здоровьем {battleUnit.Health}!");
        }
    }
}