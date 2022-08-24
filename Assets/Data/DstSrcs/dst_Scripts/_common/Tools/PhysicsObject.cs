using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject// : MonoBehaviour// BaseObject
{
    #region fields

       protected Rigidbody m_rigidbody;

        public bool m_isKinematic   //включаем
        {
            get
            {
                return m_rigidbody.isKinematic;
            }
            set
            {
                m_rigidbody.isKinematic = value;
            }
        }
    #endregion
    /*
    public override void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    */
    
}
