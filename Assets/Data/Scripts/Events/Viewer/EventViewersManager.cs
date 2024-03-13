using True10.Managers;

namespace DontStopTheTrain.Events
{
    public class EventViewersManager : DataManager<AbstractEventViewer>
    {
        public override void Initialize()
        {

        }

        public override void Dispose()
        {
            Clear();
        }
    }
}
