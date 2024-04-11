using UnityEngine;

namespace True10
{

    public class HideCursorOnStart : MonoBehaviour
    {

        void Start()
        {
            Cursor.visible = false ;
            Cursor.lockState = CursorLockMode.None;
        }

    }

}
