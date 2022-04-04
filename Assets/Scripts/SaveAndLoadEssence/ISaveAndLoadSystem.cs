namespace SaveAndLoadEssence
{
    public interface ISaveAndLoadSystem
    {
        void Save(string name, float value);
        void Save(string name, int value);
        void Save(string name, string value);
        
        T Load<T>(string name) where T : struct;
    }
}