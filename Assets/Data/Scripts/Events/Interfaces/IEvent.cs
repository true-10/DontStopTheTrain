using System;
using System.Collections.Generic;


namespace DontStopTheTrain.Events
{
    public interface IEvent
    {
        Action<IEvent> OnComplete { get; set; }
        EventId Id => StaticData.Id;
        int HashCode { get; }

        int Weight { get; }
        //не только очки действия вкладывать, но и ресурсы? да
        List<ICondition> Conditions { get; } //условия, которые должны быть выполнены для завершения ивента
        IEventStaticData StaticData { get;}//??
        EventStatus Status { get; }//??

        //List<int> int_params;
        void Initialize();
       // void Initialize(IEventInitData data);
        bool TryToComplete();


    }

}