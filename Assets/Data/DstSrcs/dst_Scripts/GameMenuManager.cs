using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameMenuManager : MonoBehaviour
{
    #region fields
    [SerializeField] private GameObject _gameMenuGUI;
    [SerializeField] private CinemachineVirtualCamera _camera;
    private bool _resumeToGame = false;
    private bool _goToMainMenu = false;
    #endregion

    public void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape) )
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        _resumeToGame = true;
    }

    public void GoToMainMenu()
    {
        Debug.Log("GoToMainMenu");
        _goToMainMenu = true;
    }

    public bool IsReadyToResume()
    {
        return _resumeToGame;
    }

    public bool IsReadyToGoToMainMenu()
    {
        return _goToMainMenu;
    }

    public void OnEnter()
    {
        Debug.Log("GameMenuManager OnEnter");
      //  CameraManager.Singleton.SetMainCamera(_camera);
        _resumeToGame = false;
        _goToMainMenu = false;
        _gameMenuGUI.SetActive(true);
    }


    public void OnExit()
    {
        Debug.Log("GameMenuManager OnExit");
        _gameMenuGUI.SetActive(false);
    }
}
