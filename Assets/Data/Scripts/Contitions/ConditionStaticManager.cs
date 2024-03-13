using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class ConditionStaticManager : StaticManager<IConditionStaticData>
    {    
        public override void Initialize()
        {
            var data = StaticDataLoader<ConditionsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.CONDITIONS_PATH);
            Datas = data.Datas;
        }
    }
}

