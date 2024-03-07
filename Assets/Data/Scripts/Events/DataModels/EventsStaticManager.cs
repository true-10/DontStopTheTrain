using System.Collections.Generic;
using True10.StaticData;

namespace DontStopTheTrain.Events
{
    public sealed class EventsStaticManager
    {
        public IReadOnlyCollection<IEventStaticData> EventsStaticData { get; private set; }

        public void Initialize()
        {
            var data = StaticDataLoader<EventsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.EVENTS_PATH);
            EventsStaticData = data.Datas;
        }
    }

}
