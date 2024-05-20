using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain.UI
{

    public class UIPlayerScreen : UIScreen
    {
        public override UIScreenID ScreenID => UIScreenID.PlayerMenu;

        [SerializeField]
        private Button _infoButton;
        [SerializeField]
        private Button _perksButton;
        [SerializeField]
        private Button _inventoryButton;
        [SerializeField]
        private Button _closeButton;


    }

}
