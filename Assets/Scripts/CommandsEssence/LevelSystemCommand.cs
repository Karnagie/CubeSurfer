using LevelsEssence;

namespace CommandsEssence
{
    public abstract class LevelSystemCommand : ICommand
    {
        protected LevelSystem _levelSystem;

        protected LevelSystemCommand(LevelSystem levelSystem)
        {
            _levelSystem = levelSystem;
        }

        public abstract void Perform();
    }
}