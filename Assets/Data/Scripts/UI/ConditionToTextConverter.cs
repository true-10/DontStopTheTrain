using System.Collections.Generic;

namespace DontStopTheTrain
{

    public static class ConditionToTextConverter
    {
        public static string GetText(IReadOnlyCollection<ICondition> conditions, int actionPoints)
        {
            string conditionsTexts = string.Empty;
            conditionsTexts += $"ActionPoints: {actionPoints} \n";
            foreach (var condition in conditions)
            {
                conditionsTexts += $"{GetText(condition)}\n";
            }
            return conditionsTexts;
        }

        public static string GetText(ICondition condition)
        {
            switch (condition.StaticData.Type)
            {
                case ConditionType.ResourceRequire:
                    return GetResourceRequireText(condition.StaticData as IConditionResourceRequireStaticData);
                case ConditionType.LevelRequire:
                case ConditionType.PerkRequire:
                default:
                    return string.Empty;
            }
        }

        private static string GetResourceRequireText(IConditionResourceRequireStaticData staticData)
        {
            return $"resource: {staticData.ResourceId} count: {staticData.Count}";
        }
    }

}
