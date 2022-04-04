using System;
using System.Reflection;

namespace SingletonEssence
{
    public class Singleton<T> where T : class
    {
        protected Singleton() { }
        
        private sealed class SingletonCreator<TS> where TS : class
        {       
            public static TS CreatorInstance { get; } = (TS) typeof(TS).GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    Type.EmptyTypes,
                    Array.Empty<ParameterModifier>())
                ?.Invoke(null);
        }

        public static T Instance => SingletonCreator<T>.CreatorInstance;
    }
}