using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeLayer : MonoBehaviour//не монобех?
{
    //ближный слой(где битва)
    //дальний слой или задник. или больше слове
    //скорость скролла. дальше от ближнего слоя медленнее. фейк 3д паралакс?
    private float _scrollSpeed { get {return -LandscapeScroller.Singleton.GetSpeed(); } }
   
    public Vector2 m_localZRange = new Vector2(-50f, 50f);

    [SerializeField] private List<LayerChunk> _chunksQueue;
  //  private Transform _transform;
    //EventController событийный контроллер? типа на этом слое что то происходит? типа запуск ракеты, или обрущение чего то


    // Start is called before the first frame update
    void Start()
    {
        // _defaultScrollSpeed = _scrollSpeed;
        //UpdateChunks();
        //_transform = GetComponent<Transform>();
    }
    
    void LastChunkToStart()
    {

    }

    void AlignChunk(Transform tr)
    {

    }

   /* public void OnUpdate()
    {

    }
 */
    public void OnLateUpdate()
    {
        foreach(LayerChunk lc in _chunksQueue)
        {
            Vector3 pos = lc.GetLocalPos();// transform.localPosition;
            pos.z += _scrollSpeed * Time.deltaTime;
            if (pos.z < m_localZRange.x)
            {
                lc.AlignToPrev();
                return;
                //pos.z = m_localZRange.y;
            }
            lc.SetLocalPos(pos);// transform.localPosition = pos;
        }

    }
}
