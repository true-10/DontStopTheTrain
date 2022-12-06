using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.UI
{

    public interface IUIFabric
    {
        GameObject CreateUI(int uiType);
    }

    public class UIFabric : MonoBehaviour, IUIFabric
    {
        [SerializeField]
        private RectTransform uiRoot;
        [SerializeField]
        private StationEventUIView StationUIPrefab;

        public GameObject CreateUI(int uiType)
        {
            switch(uiType)
            {
                default:
                    var go = Instantiate(StationUIPrefab, uiRoot);
                    return go.gameObject;
            }
        }

    }
}
