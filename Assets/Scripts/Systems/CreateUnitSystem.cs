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
            CreateOrc("Петрович", new Vector2(-1.96f, -1f));
            CreateElf("Афанасий", new Vector2(1.36f, -1f));
        }

        private void CreateOrc(string name , Vector2 position)
        {
            EcsEntity entity = _world.NewEntity();
            ref var battleUnit = ref entity.Get<BattleUnit>();
            battleUnit.Name = "орк " + name;
            battleUnit.Health = 120f;
            battleUnit.MaxHealth = 120f;

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

            var sliderHp = Object.Instantiate(_prefab.SliderHp, position, Quaternion.identity);
            entity.Get<Component<SliderHp>>().Value = sliderHp;
            sliderHp.Value = battleUnit.Health / battleUnit.MaxHealth;
            
            _world.SendMessage($"Юнит {battleUnit.Name} создан со здоровьем {battleUnit.Health}!");
            _world.SendMessage($"Со спобосбностью {blockAbility.AbilityName}");
            _world.SendMessage($"Со спобосбностью {secondChanceAbility.AbilityName}");
        }

        private void CreateElf(string name, Vector2 position)
        {
            EcsEntity entity = _world.NewEntity();
            ref var battleUnit = ref entity.Get<BattleUnit>();
            battleUnit.Name = "эльф " + name;
            battleUnit.Health = 80f;
            battleUnit.MaxHealth = 80f;

            ref var ability = ref entity.Get<Healer>();
            ability.NameAbility = "Лечение";
            ability.MinHealValue = 8f;
            ability.MaxHealValue = 15f;

            var gameObj = Object.Instantiate(_prefab.ElfPrefab);
            gameObj.GetComponent<Unit>().Entity = entity;
            
            entity.Get<Component<GameObject>>().Value = gameObj;
            entity.Get<Component<GameObject>>().Value.name = battleUnit.Name;
            
            var sliderHp = Object.Instantiate(_prefab.SliderHp, position, Quaternion.identity);
            entity.Get<Component<SliderHp>>().Value = sliderHp;
            sliderHp.Value = battleUnit.Health / battleUnit.MaxHealth;

            _world.SendMessage($"Юнит {battleUnit.Name} создан со здоровьем {battleUnit.Health}!");
        }
    }
}