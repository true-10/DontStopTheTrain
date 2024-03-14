using System.Collections.Generic;

namespace DontStopTheTrain
{
    public sealed class ActionPointsCalculator
    {
        private PerksController _perkController;

        public ActionPointsCalculator(PerksController perkController/*список перков, бафов, уровень*/)
        {
            _perkController = perkController;

        }

        private int _cachedActionPointsValue;
        private int _baseActionPointsValue = 10;

        public void Calculate()
        {
            //считаем кол-во очков в заивисимости от прокачки и прочего
            _cachedActionPointsValue = _baseActionPointsValue + _perkController.GetValue(PerkType.ActionPoint);
        }

        public int GetActionPointsCount()
        {
            return _cachedActionPointsValue;
        }

    }
}
