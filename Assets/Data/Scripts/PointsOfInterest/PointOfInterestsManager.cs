using True10.Managers;

namespace DontStopTheTrain
{
    public class PointOfInterestsManager : DataManager<PointOfInterest>
    {
        public override void Dispose()
        {
            Clear();
        }

        public override void Initialize()
        {

        }
    }
}
