using System;
using UnityEngine;

namespace DontStopTheTrain
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _root;

        public void Show()
        {
            _root.SetActive(true);
        }

        public void Hide(Action onHide = null)
        {
            onHide?.Invoke();
            _root.SetActive(false);
        }
    }
}
