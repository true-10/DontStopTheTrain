using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace True10.ParticleSystemWrapper
{
    public interface IPSEmitPoint
    {

    }

    public class PSEmitPoint : MonoBehaviour, IPSEmitPoint
    {
        #region injections
        [Inject] private IPSController psController;
        #endregion
        #region fields
        [SerializeField] private string emitterName;
        [SerializeField] private int count;
        [SerializeField] private PSEmitParams emitData; //данные для системы. или передавать в эмите?
        #endregion


        public void Emit()
        {
            psController.Emit(emitterName, emitData, count);
        }
    }


}
