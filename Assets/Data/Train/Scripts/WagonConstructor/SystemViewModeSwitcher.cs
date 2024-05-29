using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class SystemViewModeSwitcher : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameViewObject;
        [SerializeField]
        private GameObject _constructorViewObject;

        public void SwitchToConstructorMode()
        {
            _gameViewObject.SetActive(false);
            _constructorViewObject.SetActive(true);
        }

        public void SwitchToGameMode()
        {
            _gameViewObject.SetActive(true);
            _constructorViewObject.SetActive(false);
        }
    }    
}
