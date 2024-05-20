using System;
using UnityEngine;

namespace DontStopTheTrain.UI
{
    public class UIScreen : MonoBehaviour
    {
        public Action<bool> OnShow { get; set; }
        public virtual UIScreenID ScreenID => UIScreenID.None;// _screenId;

        [SerializeField]
        protected GameObject _root;
        //[SerializeField]
        //protected UIScreenID _screenId;

        public virtual void Show()
        {
            _root.SetActive(true);
            OnShow?.Invoke(true);
        }

        public void Hide()
        {
            _root.SetActive(false);
            OnShow?.Invoke(false);
        }
    }
}
