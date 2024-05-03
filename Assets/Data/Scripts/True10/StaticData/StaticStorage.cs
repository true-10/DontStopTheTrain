using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

namespace True10.StaticData
{
    public class StaticStorage<T>  : ScriptableObject where T:Object
    {
        public IReadOnlyCollection<T> Datas => _datas.AsReadOnly();

        [SerializeField]
        protected List<T> _datas;

        public T GetRandomItem()
        {
            var randomIndex = Random.Range(0, _datas.Count);
            var randomChunk = _datas[randomIndex];
            return randomChunk;
        }

        public T GetFirst()
        {
            return _datas.FirstOrDefault();
        }

        public T GetLast()
        {
            return _datas.LastOrDefault();
        }

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