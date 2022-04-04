using BusEvents;
using BusEvents.Handlers;
using CommandsEssence;
using LevelsEssence;
using UnityEngine;
using Zenject;

namespace UiEssence
{
    public class LosePanel : Panel, IGameStateHandler
    {
        [SerializeField] private UIButton _repeatUIButton;
        
        [Inject] private LevelSystem _levelSystem;
        
        private void Awake()
        {
            EventBus.Subscribe(this);
            gameObject.SetActive(false);
            _repeatUIButton.AddCommand(new RepeatLevelCommand(_levelSystem));
        }
        
        public void Win()
        {
            
        }

        public void Lose()
        {
            Show();
        }
        
        private void OnDestroy()
        {
            EventBus.Unsubscribe(this);
        }
    }
}