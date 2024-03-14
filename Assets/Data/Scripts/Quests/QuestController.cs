using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System;
using System.Data;
using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class QuestController
    {
        public Action<IQuest> OnStart { get; set; }
        public Action<IQuest> OnComplete { get; set; }

        public void Start(IQuest quest)
        {
            quest.Initialize();
            quest.OnComplete += Complete;
            OnStart?.Invoke(quest);
        }

        private void Complete(IQuest quest)
        {
            OnComplete?.Invoke(quest);
            quest.OnComplete -= Complete;
        }
    }
}