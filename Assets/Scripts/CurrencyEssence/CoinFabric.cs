using UnityEngine;

namespace CurrencyEssence
{
    [CreateAssetMenu(fileName = "CoinFabric", menuName = "Coin Fabric", order = 0)]
    public class CoinFabric : ScriptableObject
    {
        [SerializeField] private GameObject _coinPrefab;
        
        public GameObject Get(Transform parent)
        {
            GameObject coin = Instantiate(_coinPrefab, parent, true);
            coin.SetActive(false);
            coin.transform.localPosition = Vector3.zero;
            return coin;
        }
    }
}