using LevelsEssence;

namespace CommandsEssence
{
    public class NextLevelCommand :  LevelSystemCommand
    {
        public NextLevelCommand(LevelSystem levelSystem) : base(levelSystem)
        {
            
        }
        
        public override void Perform()
        {
            _levelSystem.OpenNextLevel();
        }
    }
}