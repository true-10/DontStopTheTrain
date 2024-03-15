using DontStopTheTrain.Events;
using System;
using System.Collections.Generic;

namespace DontStopTheTrain
{
    public interface IQuest
    {
        Action<IQuest> OnComplete { get; set; }
        int HashCode { get; }
        IQuestStaticData StaticData { get; }
        QuestStatus Status { get; }

        void Start();
        void Reset();
        bool TryToComplete();
    }

    public interface IQuestStaticData
    {
        // int HashCode { get; }
        QuestId Id { get; }
        QuestType Type { get; }
        IReadOnlyList<RewardId> RewardIds { get; }
        IReadOnlyCollection<IConditionStaticData> ConditionsToComplete { get; }
        Information Info { get; }

    }


    public enum QuestId
    {
        None = 0,

    }

    public enum QuestType
    {
        Unknown = 0,
        GatherResources = 1,
        CompleteEvent = 2,//??

    }

    public enum QuestStatus
    {
        None, //бездействующие
        InProgress,
        Complete
    }

  /*  public class Controller<T>
    {
        public Action<T> OnStart { get; set; }
        public Action<T> OnComplete { get; set; }

        public void StartEvent(T quest)
        {
            quest.Initialize();
            quest.OnComplete += OnEventComplete;
            OnStart?.Invoke(quest);
        }

        private void OnEventComplete(T quest)
        {
            OnComplete?.Invoke(quest);
            quest.OnComplete -= OnEventComplete;
        }
    }*/
}