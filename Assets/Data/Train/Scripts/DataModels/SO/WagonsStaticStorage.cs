using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonsStorage", menuName = "DST/Train/WagonsStorage")]
    public class WagonsStaticStorage : StaticStorage<WagonStaticDataBase>
    {
    }
}
