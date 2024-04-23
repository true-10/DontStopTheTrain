using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class Station
    {


    }

    public class StationView : MonoBehaviour
    {
        [Inject]
        private WagonsManager _wagonsManager;
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private CameraHolder _cameraHolder;

        public void Depart()
        {
            var locomotive = _wagonsManager.GetLocomotive();
            
            //locomotive.SetSpeed(100f);
        }

        public void OpenShop()
        {

        }

        public void OpenQuestList()
        {
            //список грузов для следующей станции. если условия погрузки выполняются, то можно взять. (если есть место, например)
        }

    }
}
