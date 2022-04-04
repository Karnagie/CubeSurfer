using BusEvents;
using BusEvents.Handlers;
using UnityEngine;
using Zenject;

namespace CurrencyEssence
{
    public class Currency : MonoBehaviour, IGameStateHandler
    {
        [SerializeField] private CurrencyView _view;
        [SerializeField] private int _countCoinsOnWin = 10;
        
        [Inject] private Wallet _wallet;

        private int _coinCache;

        private void Awake()
        {
            EventBus.Subscribe(this);
            _view.Init(_countCoinsOnWin);
            _view.UpdateValue(_wallet.Count);
            _view.OnGotCoin += GotCoin;
        }

        private void GotCoin()
        {
            _wallet.AddCoins(1);
            _coinCache--;
            _view.UpdateValue(_wallet.Count);
        }

        public void Win()
        {
            _coinCache = _countCoinsOnWin;
            _view.AnimateCurrency();
        }

        public void Lose()
        {
            
        }

        private void OnDestroy()
        {
            while (_coinCache > 0)
            {
                _wallet.AddCoins(1);
                _coinCache--;
            }
            EventBus.Unsubscribe(this);
        }
    }
}