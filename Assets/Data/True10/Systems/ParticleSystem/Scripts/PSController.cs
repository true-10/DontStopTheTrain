using System;
using System.Collections.Generic;
using UnityEngine;

namespace True10.ParticleSystemWrapper
{
    public static class PSNames
    {
        public const string PS_DUST = "ps_dust";
        public const string PS_WIND_SLICES = "ps_wind_slices";
    }

    public class PSEmitParams
    {

    }

    public interface IPSController
    {
        Action OnUpdate { get; set; }
        Action OnEmit { get; set; }

        //void Emit(string psName, ParticleSystem.EmitParams emitParams, int count);
        void Emit(string psName, PSEmitParams emitParams, int count);

    }

    public class PSController : IPSController, IGameLifeCycle
    {
        #region injections

        #endregion
        #region fields
        /// <summary>
        /// имя системы - ключ
        /// </summary>
        private Dictionary<string, IPSEmitter> emitters;

        #endregion

        #region callbacks
        public Action OnUpdate { get; set; }
        public Action OnEmit { get; set; }
        public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion


       // public void Emit(string psName, ParticleSystem.EmitParams emitParams, int count)
        public void Emit(string emitterName, PSEmitParams emitParams, int count)
        {
            //emitParams.applyShapeToPosition = true;
            //emitParams.
            IPSEmitter ps = emitters[emitterName];
            ps.Emit(emitParams, count);

        }

    }
}