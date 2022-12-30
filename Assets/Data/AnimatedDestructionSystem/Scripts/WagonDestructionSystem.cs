using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Animation.DestructionSystem
{
    /// <summary>
    /// разрушаемость вагонов как в полигонках. запчасти просто отлетают
    /// </summary>

    public interface IDetachable
    {
        void Detach();
    }

    public class WagonDestructionSystem : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
