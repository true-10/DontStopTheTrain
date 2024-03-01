namespace DontStopTheTrain.Train
{
    public interface IWagon
    {
        int Number { get; } //номер вагона
        IWagonStaticData StaticData { get; }
        int Deterioration { get; } //износ
        int Next { get; set; } //номер следующего
        int Prev { get; set; } //номер пред

    }

}
