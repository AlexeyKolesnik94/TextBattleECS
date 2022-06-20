using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Systems
{
    class MessageSystem : BaseSystem, IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<MessageRequest> _filter;
        private Prefabs _prefabs;
        private GameUI _gameUI;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var request = ref _filter.Get1(i);
                var text = Object.Instantiate(_prefabs.BattleText, _gameUI.MessageScrollRect.content , false);
                text.SetText(request.Message);
            }
            _gameUI.MessageScrollRect.verticalNormalizedPosition = 0f;
        }

        public void Init()
        {
            _gameUI.ClearButton.onClick.AddListener(() =>
            {
                foreach (Transform i in _gameUI.MessageScrollRect.content)
                {
                    Object.Destroy(i.gameObject);
                }
            });
        }
    }
}