using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ContainerManager : MonoBehaviour
{
    private SceneContext context;

    private static DiContainer maxContainer;
    private static List<DiContainer> containers = new List<DiContainer>();

    private void Awake()
    {
        context = GetComponent<SceneContext>();
        AddContainer(context.Container);
    }

    private void OnDestroy()
    {
        if (context != null && context.Container != null)
        {
            RemoveContainer(context.Container);
        }
    }

    public static void AddContainer(DiContainer container)
    {
        containers.Add(container);
        containers.RemoveAll(x => x == null);
        UpdateContainer();
    }

    public static void RemoveContainer(DiContainer container)
    {
        if (containers.Contains(container)) containers.Remove(container);
        containers.RemoveAll(x => x == null);
        UpdateContainer();
    }

    public static void UpdateContainer()
    {
        maxContainer = new DiContainer(containers, false);
    }

    public static DiContainer GetContainer()
    {
        return maxContainer;
    }

}

