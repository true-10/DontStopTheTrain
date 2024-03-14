using Zenject;

namespace DontStopTheTrain
{
    public sealed class QuestsFabric : IFabric<IQuest, IQuestStaticData>
    {
        [Inject]
        private Inventory _inventory;
        [Inject]
        private Player _player;

        public IQuest Create(IQuestStaticData staticData)
        {
            return new Quest(staticData);

            switch (staticData.Type)
            {
                case QuestType.Unknown:

                    return new Quest(staticData);
                default:
                    UnityEngine.Debug.Log($"The type [{staticData.Type}] is not found");
                    return null;

            }
        }
    }
}