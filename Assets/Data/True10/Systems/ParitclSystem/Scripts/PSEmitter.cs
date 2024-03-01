using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace True10.ParticleSystemWrapper
{

public interface IPSEmitter
{
    string Name { get; }
        void Emit(PSEmitParams emitParams, int count);
    }

public class PSEmitter : MonoBehaviour, IPSEmitter
{
        #region injections

        #endregion

        #region fields
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private string name;
    //private string psName;
    public string Name => name;// по имени выбирать
    #endregion
    public void Init()
    {
      //  psController.OnEmit += Emit;
    }


        public void Emit(PSEmitParams psEmitParams, int count)
        {
            ParticleSystem.EmitParams emitParams = ConvertToEmitParams(psEmitParams);
              particleSystem.Emit(emitParams, count);
            // particleSystem.Emit(emitParams, Mathf.RoundToInt( count * Time.deltaTime) );
        }

        private ParticleSystem.EmitParams ConvertToEmitParams(PSEmitParams psEmitParams)
        {
            ParticleSystem.EmitParams prms = new ParticleSystem.EmitParams();
            //prms.angularVelocity = psEmitParams.


            return prms;
        }

    }

}