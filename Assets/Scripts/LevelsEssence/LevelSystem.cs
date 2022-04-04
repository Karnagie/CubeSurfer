using SingletonEssence;
using Trisibo;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelsEssence
{
    [CreateAssetMenu(fileName = "LevelSystem", menuName = "Level system", order = 0)]
    public class LevelSystem : ScriptableObject
    {
        [SerializeField] private string _key = "Level";
        [SerializeField] private SceneField[] _scenes;
        [SerializeField] private int _tutorialLevelCount = 1;

        private int _currentLevelId;

        private void Awake()
        {
            _currentLevelId = SaveAndLoadSystem.Instance.Load<int>(_key);
#if !UNITY_EDITOR
            SceneManager.LoadScene(_scenes[_currentLevelId].BuildIndex);
#endif
        }

        public void OpenNextLevel()
        {
            _currentLevelId = (++_currentLevelId)%_scenes.Length;
            if (_currentLevelId == 0) _currentLevelId += _tutorialLevelCount;
            SaveAndLoadSystem.Instance.Save(_key, _currentLevelId);
            SceneManager.LoadScene(_scenes[_currentLevelId].BuildIndex);
        }
        
        public void RepeatLevel()
        {
            SceneManager.LoadScene(_scenes[_currentLevelId].BuildIndex);
        }

        [ContextMenu("Clear")]
        private void Clear()
        {
            _currentLevelId = 0;
            SaveAndLoadSystem.Instance.Save(_key, _currentLevelId);
        }
    }
}