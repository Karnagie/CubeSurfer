using LevelsEssence;

namespace CommandsEssence
{
    public class RepeatLevelCommand : LevelSystemCommand
    {
        public RepeatLevelCommand(LevelSystem levelSystem) : base(levelSystem)
        {
            
        }
        
        public override void Perform()
        {
            _levelSystem.RepeatLevel();
        }
    }
}