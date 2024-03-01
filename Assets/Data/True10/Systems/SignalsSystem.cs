using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.SignalsSystem
{
    public interface ISignalEmitter
    {

    }

    public interface ISignal
    {
        int Value { get; set; }
        int Type { get; set; } //тип сигнала. звук (громкометр), сила взрыва, из игрового ивентаи тд
    }

    public interface ISignalsSystem
    {

    }

    public class SignalsSystem 
    {

        public Action<ISignal> OnSignal { get; set; }
    }
}
