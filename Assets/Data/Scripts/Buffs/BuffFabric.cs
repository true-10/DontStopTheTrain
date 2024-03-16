using Zenject;

namespace DontStopTheTrain
{
    public class BuffFabric : IFabric<IBuff, IBuffStaticData>
    {
        [Inject]
        private TurnBasedController _turnBasedController;
       // [Inject]
        //private Player _player;
        [Inject]
        private PlayerBuffsManager _playerBuffsManager;

        public IBuff Create(IBuffStaticData staticData)
        {

            return new Buff(staticData, _turnBasedController, _playerBuffsManager);
            switch (staticData.Type)
            {
                case PerkType.ActionMan:
                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }
        }
    }
}
