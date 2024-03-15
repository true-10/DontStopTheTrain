using System.Collections.Generic;

namespace DontStopTheTrain
{
    public interface IQuestStaticData
    {
        // int HashCode { get; }
        QuestId Id { get; }
        QuestType Type { get; }
        IReadOnlyList<RewardId> RewardIds { get; }
        IReadOnlyCollection<IConditionStaticData> ConditionsToComplete { get; }
        Information Info { get; }

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