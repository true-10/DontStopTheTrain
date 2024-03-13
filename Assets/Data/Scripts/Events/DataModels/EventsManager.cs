using System.Collections.Generic;
using System.Linq;
using True10.Managers;
using Zenject;

namespace DontStopTheTrain.Events
{
    public sealed class EventsManager: DataManager<IEvent>
    {
        [Inject]
        private EventFabric _fabric;
        [Inject]
        private EventsStaticManager _staticManager;

        public override void Initialize()
        {
            var staticDatas = _staticManager.Datas;
            foreach (var staticData in staticDatas)
            {
                var item = _fabric.Create(staticData);
                TryToAdd(item);
            }
        }

        public override void Dispose()
        {
            Clear();
        }

        public IEvent GetEventById(EventId id)
        {
            return Items
                .FirstOrDefault(m => m.StaticData.Id == id);
        }   

        public IEvent GetFreeEventById(EventId id)
        {
            return GetAllFreeEvents()
                .FirstOrDefault(m => m.StaticData.Id == id);
        }

        public List<IEvent> GetAllFreeEvents()
        {
            return Items
                .Where(ev => ev.Status == EventStatus.None)
                .ToList();
        }
    }
}
