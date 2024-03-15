using True10.Extentions;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class UITestButton : MonoBehaviour
    {
        [Inject]
        private BuffsManager _buffsManager;
        [Inject]
        private TurnBasedController _turnBasedController;

        public void TestAction()
        {
            var randomBuff = _buffsManager.Items.GetRandomElement();
            _buffsManager.Activate(randomBuff);

        }
    }

}
