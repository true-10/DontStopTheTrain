namespace DontStopTheTrain
{
    public sealed class InventoryCallback
    {
        public InventoryOperationType OperationType { get; private set; }
        public InventoryOperationStatus OperationStatus { get; private set; }
        public InventoryItem InventoryItem { get; private set; }
        public int DeltaCount { get; private set; }
        public IItemStaticData ItemStaticData { get; private set; }

        public InventoryCallback(InventoryOperationType operation, InventoryOperationStatus status,
            InventoryItem inventoryItem, int deltaCount, IItemStaticData itemStaticData)
        {
            OperationType = operation;
            OperationStatus = status;
            InventoryItem = inventoryItem;
            DeltaCount = deltaCount;
            ItemStaticData = itemStaticData;

        }
    }

    public enum InventoryOperationType
    {
        Add = 0,
        Remove = 1
    }

    public enum InventoryOperationStatus
    {
        Success = 0,
        Fail = 1
    }
}
