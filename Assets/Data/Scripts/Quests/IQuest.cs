using DontStopTheTrain.Events;
using System;
using True10.Enums;

namespace DontStopTheTrain
{
    public interface IQuest
    {
        Action<IQuest> OnComplete { get; set; }
        int HashCode { get; }
        IQuestStaticData StaticData { get; }
        ProgressStatus Status { get; }

        void Start();
        void Reset();
        bool TryToComplete();
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