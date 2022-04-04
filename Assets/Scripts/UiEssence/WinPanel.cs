using BusEvents;
using BusEvents.Handlers;
using CommandsEssence;
using LevelsEssence;
using UnityEngine;
using Zenject;

namespace UiEssence
{
    public class WinPanel : Panel, IGameStateHandler
    {
        [SerializeField] private UIButton _nextLevelUIButton;
        
        [Inject] private LevelSystem _levelSystem;
        
        private void Awake()
        {
            EventBus.Subscribe(this);
            gameObject.SetActive(false);
            _nextLevelUIButton.AddCommand(new NextLevelCommand(_levelSystem));
        }

        public void Win()
        {
            Show();
        }

        public void Lose()
        {
            
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe(this);
        }
    }
}