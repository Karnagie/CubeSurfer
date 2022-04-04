using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace CurrencyEssence
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value;
        [SerializeField] private RectTransform _from;
        [SerializeField] private RectTransform _to;
        [SerializeField] private float _duration = 1.5f;
        [SerializeField] private float _randomizeDuration = 0.5f;
        [SerializeField] private Vector3 _randomizePosition;

        public event Action OnGotCoin;

        [Inject]private CoinFabric _coinFabric;
        private List<GameObject> _coins;

        public void Init(int winValue)
        {
            _coins = new List<GameObject>();
            for (int i = 0; i < winValue; i++)
            {
                _coins.Add(_coinFabric.Get(_from));
            }
        }

        public void UpdateValue(int walletCount)
        {
            _value.text = walletCount.ToString();
        }

        public void AnimateCurrency()
        {
            foreach (var coin in _coins)
            {
                coin.gameObject.SetActive(true);
                float duration = _duration + Random.Range(-_randomizeDuration, _randomizeDuration);
                coin.transform.position = _from.position +  _randomizePosition*Random.Range(0f, 1f);
                coin.transform.DOMove(_to.position, duration)
                    .SetEase(Ease.InOutBack).OnComplete(() => OnGotCoin?.Invoke());
            }
        }

        private void OnDestroy()
        {
            foreach (var coin in _coins)
            {
                coin.transform.DOKill();
            }
        }
    }
}