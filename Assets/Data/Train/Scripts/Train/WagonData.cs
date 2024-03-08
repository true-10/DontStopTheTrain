using Zenject;

namespace DontStopTheTrain.Train
{
    public class WagonData : IWagon
    {
        //здесь мы отслеживаем состояние вагона
        public int Number => throw new System.NotImplementedException();

        public IWagonStaticData StaticData => throw new System.NotImplementedException();
        public int Deterioration => _deterioration;

        public int Next { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Prev { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        [Inject]
        private TurnBasedController _turnBasedController;

        private int _deterioration = 100;

        public void Initialize()
        {
            _turnBasedController.OnTurnEnd += OnTurnEnd;
        }

        public void Dispose()
        {
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
        }

        private void OnTurnEnd(ITurnCallback callback)
        {
            //считаем износ вагона
            //если есть незавершенные ивенты, то износ больше
            _deterioration--;
            if (_deterioration < 0)
            {
                _deterioration = 0;
            }
        }
    }
   
}
