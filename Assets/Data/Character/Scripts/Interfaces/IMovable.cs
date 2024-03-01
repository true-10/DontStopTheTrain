
using UnityEngine;

namespace True10.Characters
{
    public interface IMovable
    {
        void Move(Vector3 direction);
        void Rotate(Vector3 angles);
    }
}
