using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    public class WagonSystemsContainer : MonoBehaviour
    {
        public List<WagonSystemHolder> SystemHolders => _systemHolders;
        public List<WagonSystemHolder> SystemEmptyHolders => _systemHolders.Where(holder => holder.IsEmpty).ToList();
        public List<WagonSystemHolder> SystemNotEmptyHolders => _systemHolders.Where(holder => holder.IsEmpty == false).ToList();

        [SerializeField]
        private List<WagonSystemHolder> _systemHolders;

        private void OnValidate()
        {
            _systemHolders = GetComponentsInChildren<WagonSystemHolder>().ToList();
        }
    }
}
