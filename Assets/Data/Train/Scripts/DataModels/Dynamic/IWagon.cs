namespace DontStopTheTrain.Train
{
    public interface IDeteriorable
    {
        int Deterioration { get; } //износ
    }

    public interface IWagon : IDeteriorable
    {
        int Number { get; } //номер вагона
        IWagonStaticData StaticData { get; }

        //int Weight { get; }//масса вагона для расчетов скорости/расхода топлива/торможения?
        int Next { get; set; } //номер следующего
        int Prev { get; set; } //номер пред

    }


}
