using System.Collections.Generic;
using UnityEngine;

namespace True10.StaticData
{
    public class StaticStorage<T>  : ScriptableObject where T:Object
    {
        public IReadOnlyCollection<T> Datas => _datas.AsReadOnly();

        [SerializeField]
        private List<T> _datas;
    }
}