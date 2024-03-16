using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonSystemsStorage", menuName = "DST/Train/WagonSystemsStorage", order = 1)]
    public class WagonSystemsStaticStorage : StaticStorage<WagonSystemStaticDataBase>
    {
    }
}
