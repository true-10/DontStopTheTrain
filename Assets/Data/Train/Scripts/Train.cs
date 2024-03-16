using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class Train : MonoBehaviour
    {
        public IReadOnlyCollection<WagonView> Wagons => _wagons.AsReadOnly();

        [SerializeField]
        private List<WagonView> _wagons;

    }
}
