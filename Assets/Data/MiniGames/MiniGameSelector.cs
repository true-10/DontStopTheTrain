using DontStopTheTrain.MiniGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSelector : MonoBehaviour
{
    [SerializeField]
    private KeyCode stopGame = KeyCode.Alpha0;
    [SerializeField]
    private List<MiniGameInfo> miniGamesList;

   // private Dictionary<KeyCode, MiniGameInfo> miniGameMap = new();

    private MiniGameInfo current;

    public void Start()
    {
       /* foreach (var gameInfo in miniGamesList)
        {
            var key = gameInfo.keyToStart;
            var game = gameInfo.miniGame;
            var gameName = gameInfo.gameName;
            if (miniGameMap.ContainsKey(key))
            {
                Debug.LogError($"The key = [{key}] for game [{gameName}] is already in use");
            }
            else
            {
                miniGameMap.Add(key, gameInfo);
            }
        }*/
    }


    private void Update()
    {
        if (current == null)
        {
            foreach (var gameInfo in miniGamesList)
            {
                if (Input.GetKey(gameInfo.keyToStart))
                {
                    gameInfo.miniGame.StartMiniGame();
                    current = gameInfo;
                    return;
                }
            }
        }
        else
        {
            if (Input.GetKey(stopGame))
            {
                current.miniGame.StopMiniGame();
                current = null;
            }
        }
    }
}

[System.Serializable]
public class MiniGameInfo
{
    public string gameName;
    public MonoMiniGame miniGame;
    public KeyCode keyToStart = KeyCode.Alpha1;
}