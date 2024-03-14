using System;

namespace DontStopTheTrain
{
    public class Quest : IQuest
    {
        public Action<IQuest> OnComplete { get; set; }

        public int HashCode => GetHashCode();

        public IQuestStaticData StaticData { get; private set; }

        public QuestStatus Status { get; private set; }

        public Quest(IQuestStaticData staticData)
        {
            StaticData = staticData;
            Status = QuestStatus.None;
        }

        public void Initialize()
        {

        }

        public bool TryToComplete()
        {
            return false;
        }
    }
}