using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class Train : MonoBehaviour
    {
        public IReadOnlyCollection<Wagon> Wagons => _wagons.AsReadOnly();

        [SerializeField]
        private List<Wagon> _wagons;

    }
}
