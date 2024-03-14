using True10.StaticData;

namespace DontStopTheTrain
{
    public sealed class QuestStaticManager : StaticManager<IQuestStaticData>
    {
        public override void Initialize()
        {
            var data = StaticDataLoader<QuestsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.QUESTS_PATH);
            Datas = data.Datas;
        }
    }
}