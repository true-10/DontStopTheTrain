using True10.Enums;

namespace DontStopTheTrain
{
    public class Buff : IBuff
    {
        public int Value => StaticData.BaseValue;
    
        public IBuffStaticData StaticData { get; private set; }
    
        public AcitveStatus Status { get; private set; }
    
        public Buff(IBuffStaticData staticData, TurnBasedController turnBasedController, PlayerBuffsManager buffsManager)
        {
            Status = AcitveStatus.Inactive;
            StaticData = staticData;
            _turnBasedController = turnBasedController;
            _buffsManager = buffsManager;
        }
    
        private TurnBasedController _turnBasedController;
        private PlayerBuffsManager _buffsManager;
        private int _endDay;
    
        public void Activate()
        {
            if (Status == AcitveStatus.Active)
            {
                return;
            }
            Status = AcitveStatus.Active;
            _turnBasedController.OnTurnStart += OnTurnStart;
            _endDay = _turnBasedController.CurrentTurn + StaticData.Time;
        }
    
        private void OnTurnStart(ITurnCallback callback)
        {
            if (callback.Number == _endDay)
            {
                Status = AcitveStatus.Inactive;
                _buffsManager.TryToRemove(this);
                _turnBasedController.OnTurnStart -= OnTurnStart;
            }
        }
    }
    
}
