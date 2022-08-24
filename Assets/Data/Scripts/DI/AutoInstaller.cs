using UnityEngine;

public class AutoInstaller : MonoBehaviour
{
    private void Awake()
    {
        var container = ContainerManager.GetContainer();
        container.InjectGameObject(gameObject);
    }
}
