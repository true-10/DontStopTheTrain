using DontStopTheTrain.Events;
using Zenject;

public class EventsSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {        
        Container.Bind<EventsManager>().AsSingle();
        Container.Bind<EventViewersManager>().AsSingle();
        Container.Bind<EventController>().AsSingle();
        Container.Bind<EventStarter>().AsSingle();
        Container.Bind<EventGenerator>().AsSingle();
        Container.Bind<EventFabric>().AsSingle();
        Container.Bind<EventsService>().AsSingle();
    }
}
