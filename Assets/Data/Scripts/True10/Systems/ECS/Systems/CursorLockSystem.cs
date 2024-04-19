using Leopotam.EcsLite;
using UnityEngine;

namespace True10.Common.ESC
{
    public class CursorLockSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
