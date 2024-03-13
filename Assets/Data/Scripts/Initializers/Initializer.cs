using UnityEngine;

namespace DontStopTheTrain
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField]
        private InitializerStaticManagers _staticManagersInitializer;
        [SerializeField]
        private InitializerManagers _managersInitializer;
        [SerializeField]
        private InitializerControllers _initializerControllers;

        private void OnValidate()
        {
            ValidateInitializers();
        }

        private void Awake()
        {
            ValidateInitializers();
            Initialize();
        }

        private void OnDestroy()
        {
            _initializerControllers.Dispose();
            _managersInitializer.Dispose();
            _staticManagersInitializer.Dispose();
        }

        private void Initialize()
        {
            _staticManagersInitializer.Initialize();
            _managersInitializer.Initialize();
            _initializerControllers.Initialize();
        }

        private void ValidateInitializers()
        {
            _staticManagersInitializer ??= GetComponent<InitializerStaticManagers>();
            _managersInitializer ??= GetComponent<InitializerManagers>();
            _initializerControllers ??= GetComponent<InitializerControllers>();
        }
    }
}