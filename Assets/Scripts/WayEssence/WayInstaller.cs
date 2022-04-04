using UnityEngine;
using Zenject;

namespace WayEssence
{
    public class WayInstaller : MonoInstaller
    {
        [SerializeField] private Way _way;
        
        public override void InstallBindings()
        {
            Container.Bind<IWay>().FromInstance(_way).AsSingle();
        }
    }
}