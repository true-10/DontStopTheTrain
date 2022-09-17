using System;
using System.Collections;
using System.Collections.Generic;

namespace Interceptors.BattleSystem
{
    public interface IController
    {
        void Init();
        void Dispose();
    }

    public interface IBattleController//:IController
    {
        IEnumerator OnUpdate();
        /// <summary>
        /// Старт боя
        /// </summary>
        Action OnBattleStart { get; set; }
        /// <summary>
        /// конце боя
        /// </summary>
        Action OnBattleEnd { get; set; }
        /// <summary>
        /// Начало хода
        /// </summary>
        Action OnTurnStart { get; set; }
        /// <summary>
        /// конец хода
        /// </summary>
        Action OnTurnEnd { get; set; }

        void SetUnits(List<IBattleUnit> units);
    }
}
