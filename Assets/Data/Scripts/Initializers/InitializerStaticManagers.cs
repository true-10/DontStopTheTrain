using Zenject;
using UnityEngine;
using DontStopTheTrain.Events;
using True10.StaticData;
using System.Linq;

namespace DontStopTheTrain
{
    public class InitializerStaticManagers : MonoBehaviour
    {
        [Inject]
        private ItemsStaticManager _itemsStaticManager;
        [Inject]
        private RewardsStaticManager _rewardsStaticManager;
        [Inject]
        private EventsStaticManager _eventsStaticManager;
        [Inject]
        private LevelsStaticManager _levelsStaticManager;
        [Inject]
        private PerksStaticManager _perkStaticManager;
        [Inject]
        private ConditionStaticManager _conditionStaticManager;

        public void Initialize()
        {
           // var itemsData = StaticDataLoader<ItemsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.ITEMS_PATH);
            _itemsStaticManager.Initialize();// itemsData.Datas.ToList());
            _rewardsStaticManager.Initialize();
            _eventsStaticManager.Initialize();
            _levelsStaticManager.Initialize();
            _perkStaticManager.Initialize();
            _conditionStaticManager.Initialize();
        }

        public void Dispose()
        {
            //_itemsStaticManager.Dispose();
            //_rewardsStaticManager.Dispose();
            //_eventsStaticManager.Dispose();
            //_levelsStaticManager.Dispose();
            //_perkStaticManager.Dispose();
            //_conditionStaticManager.Dispose();
        }
    }

}
