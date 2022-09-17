using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenuManager : MonoBehaviour
{
    #region fields
    [SerializeField] private GameObject _mainMenuGUI;
    [SerializeField] private CinemachineVirtualCamera _camera;
    private bool _readyToStartGame = false;
    #endregion
    // Start is called before the first frame update


    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }

    public void StartGame()
    {
        _readyToStartGame = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public bool IsReadyToPlay()
    {
        return _readyToStartGame;
    }

    public void OnEnter()
    {
        Debug.Log("MainMenuManager OnEnter");
        CameraManager.Singleton.SetMainCamera(_camera);
        _readyToStartGame = false;
        _mainMenuGUI.SetActive(true);
    }


    public void OnExit()
    {
        Debug.Log("MainMenuManager OnExit");
        _mainMenuGUI.SetActive(false);
    }
}
