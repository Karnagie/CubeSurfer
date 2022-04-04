using SaveAndLoadEssence;

namespace SingletonEssence
{
    public class SaveAndLoadSystem : Singleton<PlayerPrefsSystem>
    {
        private SaveAndLoadSystem() { }
    }
}