namespace DontStopTheTrain
{
    public sealed class ActionPointsCalculator
    {
        //private Inventory _inventory;

        public ActionPointsCalculator(/*список перков, бафов, уровень*/)
        {

        }

        private int _cachedActionPointsValue = 10;

        public void Calculate()
        {
            //считаем кол-во очков в заивисимости от прокачки и прочего

        }

        public int GetActionPointsCount()
        {
            return _cachedActionPointsValue;
        }
    }
}
