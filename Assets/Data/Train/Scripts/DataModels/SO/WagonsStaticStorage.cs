using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonsStorage", menuName = "DST/Train/WagonsStorage", order = 0)]
    public class WagonsStaticStorage : StaticStorage<WagonStaticDataBase>
    {
    }
}
