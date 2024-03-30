using True10;
using True10.Interfaces;
using UnityEngine;

namespace DontStopTheTrain
{
    public class StateMachineController : IGameLifeCycle
    {
        private StateMachine _stateMachine;

        public void Initialize()
        {
            _stateMachine = new StateMachine();


        }

        public void Dispose()
        {
            _stateMachine.Dispose();
        }
    }
}
