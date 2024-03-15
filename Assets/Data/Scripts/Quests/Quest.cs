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

        public void Start()
        {
            Status = QuestStatus.InProgress;
        }

        public bool TryToComplete()
        {
            return false;
        }
        public void Reset()
        {
            Status = QuestStatus.None;

        }
    }
}