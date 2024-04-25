using System;
using UnityEngine;

namespace DontStopTheTrain.UI
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _root;

        public virtual void Show()
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
