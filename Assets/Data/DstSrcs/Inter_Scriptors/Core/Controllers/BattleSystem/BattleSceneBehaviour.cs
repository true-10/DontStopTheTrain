using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Interceptors.BattleSystem.Behaviours
{
    public class BattleSceneBehaviour : MonoBehaviour
    {
        #region fields
        [SerializeField] List<VehicleUnitView> units;

        #endregion
        #region injections
        [Inject] private IBattleController battleController;
        #endregion

        #region callbacks


        #endregion

        #region  vars

        #endregion

        #region 

        #endregion
        void Start()
        {
            InitControllers();
            StartCoroutine(UpdateCoroutine());
        }


        public IEnumerator UpdateCoroutine()
        {
            yield return battleController.OnUpdate();
            yield return null;

            StartCoroutine(UpdateCoroutine());
        }

        private void InitControllers()
        {
            List<IBattleUnit> battleUnits = new List<IBattleUnit>();
            units.ForEach(x => battleUnits.Add(x.BattleUnit));
            //battleController = new BattleController();
            battleController.SetUnits(battleUnits);
        }
    }
}
