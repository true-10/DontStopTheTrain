using True10.StaticData;

namespace DontStopTheTrain.Events
{
    public sealed class EventsStaticManager : StaticManager<IEventStaticData>
    {
        public override void Initialize()        
        {
            var data = StaticDataLoader<EventsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.EVENTS_PATH);
            Datas = data.Datas;
        }
    }
}
