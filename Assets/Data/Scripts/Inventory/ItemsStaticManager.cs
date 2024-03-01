using System.Collections.Generic;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain
{
    public sealed class ItemsStaticManager
    {
        public IReadOnlyCollection<IItemStaticData> ItemStaticDatas { get; private set; }

        public void Initialize()
        {
            var data = StaticDataLoader<ItemsStaticStorage>.LoadStaticData(Constants.StaticDataPaths.ITEMS_PATH);
            ItemStaticDatas = data.Datas;
        }
    }
}
