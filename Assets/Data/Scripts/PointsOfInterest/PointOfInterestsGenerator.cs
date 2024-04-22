namespace DontStopTheTrain
{
    public class PointOfInterestsGenerator
    {
        private int minDays = 5;
        private int maxDays = 20;

        public PointOfInterest GeneratePoint(int currentDay)
        {
            var travelDays = UnityEngine.Random.Range(minDays, maxDays);
            return new PointOfInterest()
            {
                TravelDays = travelDays
            };

        }
    }
}
