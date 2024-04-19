using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    /*
     выдает нужные куски уровня 
    для переходов там с локации на локацию

     */

    [System.Serializable]
    public class ChunkSetController
    {
        private ChunkSet _chunkSet;

        public ChunkSetController(ChunkSet chunkSet)
        {
            _chunkSet = chunkSet;
        }


        public void Reset()
        {

        }

        public ChunkData GetChunk()
        {//тайлсет сам свои куски выдает по внутреннему правилу
            return null;
        }
        public bool IsEnd()
        {
            //еслие все куски отдали
            return false;
        }
    }

    [System.Serializable]
    public class ChunkSet
    {
        public float Weight;//чем больше вес, тем чаще выпадать может
        public List<ChunkData> ChunkDataList;

    }

    [System.Serializable]
    public class ChunkData
    {
        public float Weight;//чем больше вес, тем чаще выпадать может
        public int ChunkType;
        public ObjectToScroll prefab;
    }

    public interface ILevelFactory
    {

    }

    public class LevelFactory
    {
        //последовательность индексов тайлсетов
        public List<int> ChunkSetIndexSequince { get; set; }//лишнее?
                                                            //список самих тайлсетов
        public List<ChunkSetController> ChunkSetList { get; set; }
        //тайлсет сам свои куски выдает по внутреннему правилу
        //по завершении управление переходит к след тайлсету
        private int currentChunkSetIndex = 0;
        private ChunkSetController currentChunkSetController = null;

        public ChunkData GetChunk()
        {
            if (currentChunkSetController == null)
            {

                return null;
            }

            if (currentChunkSetController.IsEnd() == false)
            {
                return currentChunkSetController.GetChunk();
            }
            else
            {
                currentChunkSetIndex++;
                if (currentChunkSetIndex > ChunkSetList.Count) currentChunkSetIndex = 0;
                currentChunkSetController = ChunkSetList[currentChunkSetIndex];
                currentChunkSetController.Reset();
                return currentChunkSetController.GetChunk();
            }
            return null;
        }

    }
}
