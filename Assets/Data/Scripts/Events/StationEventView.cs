using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using True10.Animation;
using True10.DayLightSystem;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Events
{
    public interface IStationEvent : IGameEvent
    {
        //какие действия на станции?
        //получение заданий/заказов/контрактов,
        //получение награды за выполнение контрактов или штрафы
        //если есть магазин//мастерская на станции, то апгрейд поезда
        //заправка топливом
        //ремонт?
        //
    }

    /// <summary>
    /// тут отоброжаем ивент станции. ивент заканчивается с UI (кнопка отправление)
    /// </summary>
    public class StationEventView : AbstractMonoEvent
    {
        [Inject]
        private IUIFabric uiFabric;
        [Inject]
        private ILevelScrollSpeedController levelScrollSpeedController;

        [SerializeField]
        private FloatAnimationData mult;
       // [SerializeField]
        //private StationEventUIView StationEventUIViewPrefab;

        protected override void OnChangeEvent(IGameEvent gameEvent)
        {

        }

        protected override void OnComplete()
        {
            //стартуем поезд
            levelScrollSpeedController.SetMultiplayer(mult);
        }

        protected override void OnStart()
        {
            //создаем юай
            var uiGO = uiFabric.CreateUI(gameEvent.StaticData.EventType);
            if (uiGO == null)
            {
                return;
            }
            if (uiGO.TryGetComponent<StationEventUIView>(out var stationUI))
            {
                stationUI.OnDepartButtonClick += OnDepartButtonClick;
            }

            gameEvent.OnComplete += DestroyUI;

            void DestroyUI()
            {
                Destroy(uiGO);
                gameEvent.OnComplete -= DestroyUI;
            }
        }

        protected override void OnTick()
        {

        }

        protected void OnDepartButtonClick()
        {
            gameEvent?.Complete();

        }

    }
}
