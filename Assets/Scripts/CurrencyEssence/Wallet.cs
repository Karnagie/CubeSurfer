using SingletonEssence;
using UnityEngine;

namespace CurrencyEssence
{
    [CreateAssetMenu(fileName = "Wallet", menuName = "Wallet", order = 0)]
    public class Wallet : ScriptableObject
    {
        [SerializeField] private string _key = "Currency";
        [SerializeField] private int _count;

        private void Awake()
        {
            _count = SaveAndLoadSystem.Instance.Load<int>(_key);
        }

        public int Count => _count;

        public void AddCoins(int value)
        {
            if(value < 0) return;
            _count++;
            SaveAndLoadSystem.Instance.Save(_key, _count);
        }
    }
}