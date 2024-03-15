using System;
using True10.Enums;

namespace DontStopTheTrain
{
    public class Quest : IQuest
    {
        public Action<IQuest> OnComplete { get; set; }

        public int HashCode => GetHashCode();

        public IQuestStaticData StaticData { get; private set; }

        public ProgressStatus Status { get; private set; }

        public Quest(IQuestStaticData staticData)
        {
            StaticData = staticData;
            Status = ProgressStatus.None;
        }

        public void Start()
        {
            Status = ProgressStatus.InProgress;
        }

        public bool TryToComplete()
        {
            return false;
        }
        public void Reset()
        {
            Status = ProgressStatus.None;

        }
    }
}