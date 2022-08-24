using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Interceptors.BattleSystem
{
    public interface ICameraBattleController
    {
        void Init();
    }

    public class CameraBattleController : MonoBehaviour, ICameraBattleController
    {
        #region injections
        [Inject] private IBattleController battleController;
        #endregion

        #region 
        #endregion

        #region 
        #endregion

        public void Init()
        {
            battleController.OnBattleStart += OnBattleStartHandler;
            battleController.OnBattleEnd += OnBattleEndtHandler;
            battleController.OnTurnStart += OnTurnStartHandler;
            battleController.OnTurnEnd += OnTurnEndHandler;
        }

        private void OnBattleStartHandler()
        {

        }
        private void OnBattleEndtHandler()
        {

        }
        private void OnTurnStartHandler()
        {

        }
        private void OnTurnEndHandler()
        {

        }

        #region monobehaviour methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion
    }
}
