using UnityEngine;

namespace DontStopTheTrain.Events
{
    public class ConditionBase : ScriptableObject, IConditionStaticData
    {
       // public ConditionId Id => _id;

        public virtual ConditionType Type => ConditionType.None;


      //  [SerializeField, Min(0)]
        //private ConditionId _id;
        [SerializeField, Min(0)]
        private int _weight;
    }

  /*  public enum ConditionId //надо ли вообще, если напрямую в статику даем данные?
    {
        None = 0,
        Credits_1k = 1,

    }*/
}