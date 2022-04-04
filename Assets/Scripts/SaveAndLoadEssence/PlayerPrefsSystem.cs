using System;
using UnityEngine;

namespace SaveAndLoadEssence
{
    public class PlayerPrefsSystem : ISaveAndLoadSystem
    {
        private PlayerPrefsSystem() { }
        
        public void Save(string name, float value)
        {
            PlayerPrefs.SetFloat(name, value);
        }

        public void Save(string name, int value)
        {
            PlayerPrefs.SetInt(name, value);
        }

        public void Save(string name, string value)
        {
            PlayerPrefs.SetString(name, value);
        }

        public T Load<T>(string name) where T : struct
        {
            if (typeof(T) == typeof(float))
            {
                return (T)(object)PlayerPrefs.GetFloat(name);
            }
            if (typeof(T) == typeof(int))
            {
                return (T)(object)PlayerPrefs.GetInt(name);
            }
            if (typeof(T) == typeof(string))
            {
                return (T)(object)PlayerPrefs.GetString(name);
            }

            throw new Exception($"The type not found");
        }
    }
}