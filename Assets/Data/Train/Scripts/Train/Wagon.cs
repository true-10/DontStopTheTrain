using DontStopTheTrain.Events;
using System.Collections;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class Wagon : MonoBehaviour
    {
        //  [SerializeField]
        //private List<MonoWagonEvent> eventsPresenter;
        //[SerializeField] 
        //private WagonData wagonData;
        //[SerializeField] private List<AbstractMonoEvent> events;
        [SerializeField] 
        private GameObject uiObject;


        //перенести
        private void ShowUI(bool isShow)
        {
            if (uiObject.activeInHierarchy != isShow)
            {
                uiObject.SetActive(isShow);
            }
        }
    }
}
