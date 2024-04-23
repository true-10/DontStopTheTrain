namespace DontStopTheTrain
{
    public class PointOfInterestsGenerator
    {
        private int minDays = 5;
        private int maxDays = 20;

        public PointOfInterest GeneratePoint(int currentDay)
        {
            var travelDays = UnityEngine.Random.Range(currentDay + minDays, currentDay + maxDays);
            return new PointOfInterest()
            {
                TravelDays = travelDays,
                ChunkType = True10.LevelScrollSystem.ChunkType.Station

            };

        }
    }
}
