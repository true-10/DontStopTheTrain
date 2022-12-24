using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//перенести в тру10
namespace DontStopTheTrain.Events
{
    public interface ICondition
    {
        int ConditionId { get; }
        int Weight { get; }
        int ConditionType { get; }
        bool IsMet();
    }

    public interface IEventCondition : ICondition
    {

    }

    public interface IResourceRequireCondition : ICondition
    {
        int ResourceId { get; }
        int Count { get; }
    }

    public interface IConditionController
    {
        bool IsConditionTheMostHeaviest(ICondition condition);
        void ActivateCondition(int conditionId);
    }


    public class ConditionController : IConditionController
    {
        private List<ICondition> allConditions = new List<ICondition>();

        private List<ICondition> activeConditions = new List<ICondition>();

        public bool IsConditionTheMostHeaviest(ICondition condition)//, int type = 0)//0 - всех типов
        {
            return false;
        }


        public void ActivateCondition(int conditionId)
        {
            var condition = allConditions.First(x => x.ConditionId == conditionId);
            if (condition == null)
            {
                return;
            }

            activeConditions.Add(condition);
        }
    }
}
