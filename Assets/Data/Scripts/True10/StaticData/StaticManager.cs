using DontStopTheTrain;
using System.Collections.Generic;
using True10.Interfaces;
using UnityEngine;

namespace True10.StaticData
{
    public class StaticManager<T, Storage>
        where Storage : StaticStorage<T> 
        where T : Object
    {
        public IReadOnlyCollection<T> Datas { get; protected set; }

        public void Initialize(string path)
        {
            var data = StaticDataLoader<Storage>.LoadStaticData(path);
            if (data == null)
            {
                UnityEngine.Debug.Log($"Cant load a storage");
                return;
            }
            Datas = data.Datas;
        }
    }
}
