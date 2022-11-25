using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    public class PlayerDataManager : MonoBehaviour
    {
        [SerializeField] private PlayerDataModel playerInfo;

        //что должен делать игрок?
        //прокачиваться
        //тратить очки?

        void Start()
        {

        }

        void Update()
        {

        }

        public void TryToPerformAction(int eventId)
        {
            //пытаемся починить что то
            //отнимаем очки действия
            //получаем опыт
        }

        //прокачка
        public void LevelUp()
        {

        }
    }
}
