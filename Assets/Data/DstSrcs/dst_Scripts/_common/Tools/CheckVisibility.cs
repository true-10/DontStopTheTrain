using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVisibility : MonoBehaviour
{
    private bool m_isVisible = false;

    private void OnBecameVisible()
    {
        m_isVisible = true;
    }

    private void OnBecameInvisible()
    {
        m_isVisible = false;
    }

    public bool IsVisible()
    {
        return m_isVisible;
    }
}
