using UnityEngine;

namespace True10.DI
{
    public class AutoInstaller : MonoBehaviour
    {
        protected void Awake()
        {
            InjectGO();
        }

        protected void InjectGO()
        {
            var container = ContainerManager.GetContainer();
            container.InjectGameObject(gameObject);
        }
    }
}
