namespace DontStopTheTrain
{
    public class Perk : IPerk
    {
        public int Value => StaticData.Value;

        public int Level => 1;

        public IPerkStaticData StaticData { get; }

        public Perk(IPerkStaticData staticData)
        {
            StaticData = staticData;
        }

    }
}
