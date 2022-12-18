using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//перенести в тру10
namespace DontStopTheTrain.Events
{
    public interface ICondition
    {
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
}
