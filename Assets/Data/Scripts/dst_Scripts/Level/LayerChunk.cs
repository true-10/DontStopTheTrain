using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChunk_
{
    #region fields
    //меш
    //трансформ
    //старт енд

    #endregion
}

public class LayerChunk : MonoBehaviour//не монобех?
{
    #region fields
    //если кусок поворотный или какой то такой, то указать тип?
    public enum ChunkType
    {
        CT_STRAIGHT = 0, //прямой участок
        CT_TURN_TO_THE_LEFT = 0, //поворот налево
    }
    private Transform _transform;
    [SerializeField] public Transform _startPoint;//   { get; private set; } //vector3? еще вращение надо
    public Transform _endPoint;//    { get; private set; }
    public LayerChunk _prev;
    #endregion

    private void Start()
    {
        _transform = GetComponent<Transform>();    
    }
    void Alignment(Transform pointToAlign)
    {
        if (pointToAlign == null)
        {
            Debug.Log(name + " Alignment error: pointToAlign == null");
            return;
        }
        //m_alignPoint = pointToAlign;
        _transform.rotation = pointToAlign.rotation;
        _transform.position = pointToAlign.position;

        _transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -_startPoint.localPosition;
    }
    public void AlignToPrev()
    {
        Alignment(_prev._endPoint);
    }

    public Vector3 GetLocalPos()
    {
        return _transform.localPosition;
    }

    public void SetLocalPos(Vector3 newPos)
    {
        _transform.localPosition = newPos;
    }
}
