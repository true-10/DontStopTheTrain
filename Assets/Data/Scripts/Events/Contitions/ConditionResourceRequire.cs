namespace DontStopTheTrain.Events
{
    public interface IConditionResourceRequire : ICondition
    {
        ItemId ResourceId { get; }
        int Count { get; }
    }

    public class ConditionResourceRequire : IConditionResourceRequire
    {
        public ItemId ResourceId => _staticData.ResourceId;

        public int Count => _staticData.Count;

        public IConditionStaticData StaticData => _staticData;

        private IConditionResourceRequireStaticData _staticData;
        private Inventory _inventory;

        public ConditionResourceRequire(IConditionResourceRequireStaticData staticData, Inventory inventory)
        {
            _staticData = staticData;
            _inventory = inventory;
        }

        public bool IsMet()
        {
            return _inventory.IsEnough(_staticData.ResourceId, _staticData.Count);
        }

    }
    
}
