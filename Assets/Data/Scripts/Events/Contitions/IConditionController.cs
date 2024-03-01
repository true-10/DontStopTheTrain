
using System.Collections.Generic;

namespace DontStopTheTrain.Events
{
    public interface IConditionController
    {
        bool IsConditionTheMostHeaviest(ICondition condition);
        void ActivateCondition(int conditionId);
    }

    public interface IEventCondition : ICondition
    {

    }


   /* public class ConditionController : IConditionController
    {
        private List<ICondition> allConditions = new List<ICondition>();

        private List<ICondition> activeConditions = new List<ICondition>();

        public bool IsConditionTheMostHeaviest(ICondition condition)//, int type = 0)//0 - всех типов
        {
            return false;
        }


        public void ActivateCondition(int conditionId)
        {
            var condition = allConditions.First(x => x.Id == conditionId);
            if (condition == null)
            {
                return;
            }

            activeConditions.Add(condition);
        }
    }*/
}
