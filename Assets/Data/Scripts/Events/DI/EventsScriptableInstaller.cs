using DontStopTheTrain;
using DontStopTheTrain.Events;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EventsScriptableInstaller", menuName = "DST/DI/Installers/EventsScriptableInstaller")]
public class EventsScriptableInstaller : ScriptableObjectInstaller<EventsScriptableInstaller>
{
    [SerializeField]
    private EventsStaticStorage _eventsStaticStorage;
    public override void InstallBindings()
    {
        Container.Bind<EventsStaticStorage>().FromScriptableObject(_eventsStaticStorage).AsSingle();
        Container.Bind<EventFabric>().AsSingle();
        Container.Bind<EventsManager>().AsSingle();
        Container.Bind<EventViewersManager>().AsSingle();
        Container.Bind<EventController>().AsSingle();
        Container.Bind<EventStarter>().AsSingle();
        Container.Bind<EventGenerator>().AsSingle();
        Container.Bind<EventsService>().AsSingle();
    }
}