namespace DontStopTheTrain
{
    public interface IConditionLevelRequire : ICondition
    {

    }

    public class ConditionLevelRequire : IConditionLevelRequire
    {
        public IConditionStaticData StaticData => _staticData;

        private IConditionLevelRequireStaticData _staticData;
        private Player _player;

        public ConditionLevelRequire(IConditionLevelRequireStaticData staticData, Player player)
        {
            _staticData = staticData;
            _player = player;
        }

        public bool IsMet()
        {
            return _staticData.IsMet(_player.Level.Value);
        }

    }
}
