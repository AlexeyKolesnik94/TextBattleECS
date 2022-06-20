using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine.SceneManagement;

namespace Systems
{
    internal class ResetGameSystem : BaseSystem, IEcsInitSystem
    {
        private GameUI _gameUI; 
        
        public void Init()
        {
            _gameUI.ResetGamBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Game");
            });
        }
    }
}