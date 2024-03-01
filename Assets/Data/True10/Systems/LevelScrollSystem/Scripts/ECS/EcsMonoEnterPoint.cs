using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Voody.UniLeo;
using Zenject;

namespace True10.LevelScrollSystem.ESC
{
    public class EcsMonoEnterPoint : MonoBehaviour
    {
        #region vars
        private EcsWorld world;
        private EcsSystems runSystems;
        //private EcsSystems initSystems;
        #endregion

        [SerializeField] 
        private ChunkSpawner spawner;
        [Inject] 
        private ILevelScrollSpeedController levelScrollSpeedController;

        private bool isInited = false;
        #region mono

        private void Start()
        {
            /*initSystems = new EcsSystems(world);

            initSystems.ConvertScene();

            initSystems
                .Add(new SpawnChunksSystem())
                .Init();*/
            spawner.SpawnChunks(InitSystems);
            //InitSystems();
        }

        private void OnDestroy()
        {
            //if (initSystems != null)
            //{
            //    initSystems.Destroy();
            //    initSystems = null;
            //}

            if (runSystems == null)
                return;

            runSystems.Destroy();
            runSystems = null;
            world.Destroy();
            world = null;
        }

        private void Update()
        {
            if (isInited == false)
            {
                return;
            }
            if (runSystems == null)
            {
                return;
            }
            runSystems?.Run();
        }

        private void LateUpdate()
        {
            //lateUpdateSystems.Run();
        }

        #endregion

        #region EcsMonoEnterPoint
        private void InitSystems()
        {
            world = new EcsWorld();
            runSystems = new EcsSystems(world);

         //   runSystems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();
            
            runSystems
                .Init();
            isInited = true;
        }

        private void AddSystems()
        {
            runSystems
               // .Add(new SpawnChunksSystem()) //заспавненые куски не видят след системы
                .Add(new InitChunksSystem())
                .Add(new ScrollChunkSystem())
                .Add(new SnapChunkToNextSystem());
        }

        private void AddInjections()
        {
      //      runSystems
        //        .Inject(levelScrollSpeedController);
        }

        private void AddOneFrames()
        {
          //  runSystems.OneFrame<SnapChunkEvent>();
        }
        #endregion
    }
}
