namespace DontStopTheTrain
{
    public class PointOfInterestsGenerator
    {
        private int minDays = 3;
        private int maxDays = 10;

        public PointOfInterest GeneratePoint(int currentDay)
        {
            var travelDays = currentDay + UnityEngine.Random.Range(minDays, maxDays);
            return new PointOfInterest()
            {
                TravelDays = travelDays,
                ChunkType = True10.LevelScrollSystem.ChunkType.Station

            };

        }
    }
}
