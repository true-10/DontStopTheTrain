using System.Collections.Generic;

namespace DontStopTheTrain
{
    public sealed class ActionPointsCalculator
    {
        public int ActionPoints { get; private set; }

        public ActionPointsCalculator(BuffAndPerksService buffAndPerksService)
        {
            _buffAndPerksService = buffAndPerksService;

        }

        private BuffAndPerksService _buffAndPerksService;
        private int _baseActionPointsValue = 10;

        public void Calculate()
        {
            //считаем кол-во очков в заивисимости от прокачки и прочего
            ActionPoints = _baseActionPointsValue + _buffAndPerksService.GetValue(PerkType.ActionPoint);
        }
    }
}
