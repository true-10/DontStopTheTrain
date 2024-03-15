using Zenject;
using UnityEngine;
using DontStopTheTrain.Events;
using True10.StaticData;
using System.Linq;

namespace DontStopTheTrain
{
    public class InitializerStaticManagers : MonoBehaviour
    {
     /*   [Inject]
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
        [Inject]
        private QuestStaticManager _questStaticManager;
        [Inject]
        private BuffsStaticManager _buffsStaticManager;
     */
        public void Initialize()
        {
            /*_itemsStaticManager.Initialize(Constants.StaticDataPaths.ITEMS_PATH);
            _rewardsStaticManager.Initialize(Constants.StaticDataPaths.REWARDS_PATH);
            _eventsStaticManager.Initialize(Constants.StaticDataPaths.EVENTS_PATH);
            _levelsStaticManager.Initialize(Constants.StaticDataPaths.LEVELS_PATH);
            _perkStaticManager.Initialize(Constants.StaticDataPaths.PERKS_PATH);
            _conditionStaticManager.Initialize(Constants.StaticDataPaths.CONDITIONS_PATH);
            _questStaticManager.Initialize(Constants.StaticDataPaths.QUESTS_PATH);
            _buffsStaticManager.Initialize(Constants.StaticDataPaths.BUFFS_PATH);*/
        }

        public void Dispose()
        {
            //_itemsStaticManager.Dispose();
            //_rewardsStaticManager.Dispose();
            //_eventsStaticManager.Dispose();
            //_levelsStaticManager.Dispose();
            //_perkStaticManager.Dispose();
            //_conditionStaticManager.Dispose();
            //_questStaticManager.Dispose();
        }
    }

}
