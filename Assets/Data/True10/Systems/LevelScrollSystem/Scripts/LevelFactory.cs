using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    /*
     ������ ������ ����� ������ 
    ��� ��������� ��� � ������� �� �������

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
        {//������� ��� ���� ����� ������ �� ����������� �������
            return null;
        }
        public bool IsEnd()
        {
            //����� ��� ����� ������
            return false;
        }
    }

    [System.Serializable]
    public class ChunkSet
    {
        public float Weight;//��� ������ ���, ��� ���� �������� �����
        public List<ChunkData> ChunkDataList;

    }

    [System.Serializable]
    public class ChunkData
    {
        public float Weight;//��� ������ ���, ��� ���� �������� �����
        public int ChunkType;
        public ObjectToScroll prefab;
    }

    public interface ILevelFactory
    {

    }

    public class LevelFactory
    {
        //������������������ �������� ���������
        public List<int> ChunkSetIndexSequince { get; set; }//������?
                                                            //������ ����� ���������
        public List<ChunkSetController> ChunkSetList { get; set; }
        //������� ��� ���� ����� ������ �� ����������� �������
        //�� ���������� ���������� ��������� � ���� ��������
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
