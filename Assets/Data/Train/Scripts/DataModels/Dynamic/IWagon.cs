﻿using DontStopTheTrain.Events;
using System;
using System.Collections.Generic;
using True10.Interfaces;
using UniRx;

namespace DontStopTheTrain.Train
{
    public interface IHealthable
    {
        IReadOnlyReactiveProperty<int> MaxHealth { get; }
        IReadOnlyReactiveProperty<int> Health { get; }
    }

    public interface IWagon: IGameLifeCycle //: IWagonSystem
    {
        Action<IEvent, IWagonSystem> OnEventStarted { get; set; }
        Action<SystemChangedCallback> OnSystemChanged { get; set; }
        //Action<IWagonSystem> OnSystemFocus { get; set; }
        Action<IWagon> OnFocus { get; set; }
        IWagonStaticData StaticData { get; }
        // int Number { get; } //номер вагона
        IReadOnlyCollection<IWagonSystem> Systems { get; }

        // int Next { get; set; } //номер следующего
        //int Prev { get; set; } //номер пред

        void TryToFocus();

        void AddSystem(IWagonSystem mewSystem);
        void RemoveSystem(IWagonSystem mewSystem);

        


    }


}
