using DontStopTheTrain.Events;
using System.Collections.Generic;

public static class ConditionToTextConverter
{
    public static string GetText(List<ICondition> conditions, int actionPoints)
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
            default:
                return string.Empty;
        }
    }

    private static string GetResourceRequireText(IConditionResourceRequireStaticData staticData)
    {
        return $"resource: {staticData.ResourceId} count: { staticData.Count}";
    }
}
