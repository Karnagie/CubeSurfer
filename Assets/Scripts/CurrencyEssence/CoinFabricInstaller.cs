using UnityEngine;
using Zenject;

namespace CurrencyEssence
{
    public class CoinFabricInstaller : MonoInstaller
    {
        [SerializeField] private CoinFabric _fabric;
        
        public override void InstallBindings()
        {
            Container.Bind<CoinFabric>().FromInstance(_fabric).AsSingle();
        }
    }
}