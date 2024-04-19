using System.Collections.Generic;
using UnityEngine;

namespace True10.Utils
{
    public sealed class EnableObjectsOnStart : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> objects;

        private void Start()
        {
            objects.ForEach(o => o.SetActive(true));
        }
    }
}
