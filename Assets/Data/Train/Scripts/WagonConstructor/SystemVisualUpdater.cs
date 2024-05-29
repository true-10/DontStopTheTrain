using System.Linq;
using True10.Utils;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{

    public class VisualDataList : SpecList<WagonSystemVisualData>
    {

    }

    public class SystemVisualUpdater : MonoBehaviour
    {
        [Inject]
        private WagonPartsStaticStorage _wagonPartsStaticStorage;

        [SerializeField]
        private WagonSystemObject _wagonSystemObject;

        private VisualDataList _visualDataList = new();

        private IWagonSystemVisualData _defaultVisualData;

        public void Initialize()
        {
            _defaultVisualData = _wagonSystemObject.WagonSystem.StaticData.VisualData;
            var partType = _defaultVisualData.Type;
            var visualDatas = _wagonPartsStaticStorage.Datas.Where(part => part.Type == partType).ToList();
            _visualDataList.SetItems(visualDatas);
        }

        public void NextVisualModel()
        {
            var partStatic = _visualDataList.GetNextItem();

            TryToReplace(partStatic);
        }

        public void PrevVisualModel()
        {
            var partStatic = _visualDataList.GetPrevItem();

            TryToReplace(partStatic);
        }

       
        public void CommitUpdate()
        {
            //еще статику надо менять при апплае
            //и сохраняемся
        }

        public void Undo()
        {
            TryToReplace(_defaultVisualData);
        }

        private void TryToReplace(IWagonSystemVisualData wagonSystemStaticData)
        {
            var prefab = wagonSystemStaticData.Prefab;
            var target = _wagonSystemObject.VisualGameObject;
            GameObjectReplacer.Replace(target, prefab, OnReplacemenComplete);
            
        }

        private void OnReplacemenComplete(GameObject gameObject)
        {
            _wagonSystemObject.SetNewVisualObject(gameObject);
        }

    }
}
