using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonPartsStorage", menuName = "DST/Train/WagonPartsStorage", order = 0)]
    public class WagonPartsStaticStorage : StaticStorage<WagonPartStaticData>
    {
    }
}
