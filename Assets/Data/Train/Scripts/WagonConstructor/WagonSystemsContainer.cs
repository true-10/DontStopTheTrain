using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    public class WagonSystemsContainer : MonoBehaviour
    {

        [SerializeField]
        private List<WagonSystemHolder> _systemHolders;

        private void OnValidate()
        {
            _systemHolders = GetComponentsInChildren<WagonSystemHolder>().ToList();
        }
    }
}
