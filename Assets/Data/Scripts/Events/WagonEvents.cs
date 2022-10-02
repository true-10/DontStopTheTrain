using DontStopTheTrain.Train;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events
{

    public interface IWagonEventFabric
    {
        IWagonEvent GetEventById(int id);
    }


    public interface IWagonEventCallback
    {
        IWagonEvent WagonEvent { get; set; } //или только айдишник?,
        GameEventStatus Status { get; set; }
        //статус
    }

    /// <summary>
    ///некое событие, которое может произойти в вагоне
    ///накрылась система вентиляции
    ///сломались тормоза
    ///взорвалась жопа
    /// </summary>
    public interface IWagonEvent : IGameEvent
    {
        IWagonType WagobType { get; } //на какой тип вагонов распространяется это событие
    }

}
