using System;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;
using UniRx;
using DG.Tweening;

namespace DontStopTheTrain.Events
{
    public class LandscapeViewEvent : MonoBehaviour
    {

    }
    /*
public class EventByTimer //: IGameEvent
{
   public int Id => throw new NotImplementedException();

   public EventStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

   public int ActionPointPrice => throw new NotImplementedException();

   public int EventType => throw new NotImplementedException();

   public Action Fire { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
   public Action OnComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}


public class LandscapeViewEvent : AbstractMonoEvent
{
   [Inject] private IGameEventController gameEventController;
   [Inject] private ICameraController cameraController;
   [Inject] private ITurnBasedController turnController;
   // [Inject] private IDispose 

   [SerializeField] private CameraHolder eventCameraHolder;
   [SerializeField] private CameraHolder defaultCameraHolder;
   [SerializeField] private float duration;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private Transform startTransform;
   [SerializeField] private Transform endTransform;

   public int Id => 1;




   private void OnTurnEndHandler(ITurnCallback callback)
   {

   }

   void Update()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           if (gameEvent == null)
           {
               return;
           }
           gameEvent.Start();
       }
   }


   protected override void Init()
   {
       base.Init();
       turnController.OnTurnEnd += OnTurnEndHandler;
       eventCameraHolder.transform.position = startTransform.position;
   }

   protected override void OnChangeEvent(IEvent gameEvent)
   {
   }

   protected override void OnComplete()
   {
   }

   protected override void OnStart()
   {
       OnEventStart?.Invoke();
       eventCameraHolder.transform.position = startTransform.position;
       eventCameraHolder.transform
           .DOLocalMoveZ(endTransform.position.z, duration)
           .SetEase(Ease.Linear);

       cameraController.SwitchToCamera(eventCameraHolder.HashCode);
       //завершить событие и сообщить об этом
       //разные контроллеры обрабатывают свои ивент тайпы
       //если

       var timer = Observable.Timer(TimeSpan.FromSeconds(duration))
           .Subscribe(x =>
           {
               if (audioSource != null)
               {
                   audioSource?.Play();
               }
               cameraController.SwitchToCamera(defaultCameraHolder.HashCode);
               eventCameraHolder.transform.position = startTransform.position;
               gameEvent.Complete();
           }
           );
   }

   protected override void OnTick()
   {
   }
}
*/
}
