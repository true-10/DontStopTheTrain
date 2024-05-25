using System.Collections;
using System.Collections.Generic;
using True10.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DontStopTheTrain.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public abstract class AbstractInputReader: AbstractGameLifeCycleBehaviour
    {
        protected PlayerInput _playerInput;

        public abstract void ActionsInitialize();

        public override void Initialize()
        {
            _playerInput = GetComponent<PlayerInput>();
            ActionsInitialize();
        }
    }

    public class DSTGameInputReader : AbstractInputReader
    {
        public bool IsPlayerScreebPressed => _playerScreenAction.ReadValue<float>() > 0.5f;

        private InputAction _playerScreenAction;

        const string PLAYER_SCREEN = "PlayerScreen";
        public override void ActionsInitialize()
        {
            _playerScreenAction = _playerInput.actions[PLAYER_SCREEN];
        }

        public override void Dispose()
        {
        }

    }

}
