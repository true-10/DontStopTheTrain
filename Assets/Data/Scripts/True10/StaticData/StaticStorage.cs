using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace True10.StaticData
{
    public class StaticStorage<T>  : ScriptableObject// where T:Object
    {
        public IReadOnlyCollection<T> Datas => _datas.AsReadOnly();

        [SerializeField]
        protected List<T> _datas;

      /*  private void OnValidate()
        {
            FindAllDatas();
        }

        [ContextMenu("Find All")]
        public void FindAllDatas()
        {
            _datas = Resources.FindObjectsOfTypeAll<T>().ToList();
        }*/
    }
}