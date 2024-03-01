using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamController : MonoBehaviour
{
    [SerializeField]
    private CharacterBehaviour character;

    private Vector3 inputAxis = Vector3.zero;

    public void Start()
    {
        character ??= GetComponent<CharacterBehaviour>();
    }

    public void OnValidate()
    {
        character ??= GetComponent<CharacterBehaviour>();
    }


    private void Update()
    {
        InputUpdate();
        CharacterUpdate();
    }

    private void CharacterUpdate()
    {
        if (character == null)
        {
            return;
        }
        character.Move(inputAxis);
        character.Rotate(inputAxis);
    }

    private void InputUpdate()
    {

        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.X))
        {
          //  character.Attack();
        }
    }
}
