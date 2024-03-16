using UniRx;

namespace DontStopTheTrain.Train
{
    public class WagonSystem : IWagonSystem
    {
        public IWagonSystemStaticData StaticData => _staticData;
        public int Price { get; private set; }
        public int EnergyConsumption { get; private set; }
        public int DeteriorationSpeed => StaticData.BaseDeteriorationSpeed;
        public int Weight => StaticData.Weight;
        public IReadOnlyReactiveProperty<int> MaxHealth => _maxHealth;
        public IReadOnlyReactiveProperty<int> Health => _health;

        public WagonSystem(IWagonSystemStaticData staticData, TurnBasedController turnBasedController,
    BuffAndPerksService buffAndPerksService)
        {
            _staticData = staticData;
            _turnBasedController = turnBasedController;
            _buffAndPerksService = buffAndPerksService;
        }

        private TurnBasedController _turnBasedController;
        private BuffAndPerksService _buffAndPerksService;

        public ReactiveProperty<int> _maxHealth;
        private IWagonSystemStaticData _staticData;

        private ReactiveProperty<int> _health;

        public void Initialize()
        {
            _health = new(StaticData.MaxHealth);
            _maxHealth = new(StaticData.MaxHealth);
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        public void Dispose()
        {
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
        }

        private void OnTurnEnd(ITurnCallback callback)
        {
            //считаем износ вагона
            //если есть незавершенные ивенты, то износ больше (перк или дебафф на время действия ивента)
            //int eventDebuff = 0;
          //  if(active)
            int repairServiceValue = _buffAndPerksService.GetValue(PerkType.RepairService);
            _health.Value -= DeteriorationSpeed + repairServiceValue;
            if (_health.Value < 0)
            {
                _health.Value = 0;
            }
        }
    }
}
