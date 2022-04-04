using UnityEngine;
using Zenject;

namespace LevelsEssence
{
    public class LevelSystemInstaller : MonoInstaller
    {
        [SerializeField] private LevelSystem _system;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelSystem>().FromInstance(_system).AsSingle();
        }
    }
}