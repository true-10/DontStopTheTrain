using DontStopTheTrain.Train;
using True10.Managers;

namespace DontStopTheTrain
{
    public class WagonObjectsManager : DataManager<WagonObject>
    {
        public WagonObject SelectedWagonObject { get; private set; }

        public void SetSelectedWagon(WagonObject wagonObject)
        {
            SelectedWagonObject = wagonObject;
        }

        public override void Initialize()
        {

        }

        public override void Dispose()
        {
            Clear();
        }
    }
    public class WagonSystemObjectsManager : DataManager<WagonSystemObject>
    {
        public WagonSystemObject SelectedSystemObject { get; private set; }

        public void SetSelectedWagon(WagonSystemObject wagonSystemObject)
        {
            SelectedSystemObject = wagonSystemObject;
        }

        public override void Initialize()
        {

        }

        public override void Dispose()
        {
            Clear();
        }
    }
}
