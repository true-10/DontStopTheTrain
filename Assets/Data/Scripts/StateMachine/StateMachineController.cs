using True10;
using UnityEngine;

namespace DontStopTheTrain
{
    public class StateMachineController
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
