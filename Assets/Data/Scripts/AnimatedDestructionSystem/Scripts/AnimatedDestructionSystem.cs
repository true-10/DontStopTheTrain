using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Animation.DestructionSystem
{
    /// <summary>
    /// по сути какая то заранее настроенная разрушаемость, зависит от силы и направления. хер понял чо написал, но сейча я понял.
    /// короче, направление силы это просто "множитель" анимации
    /// перехват контроля и фейд в "свободное падение"
    /// Например, анимация взрыв. типа просто предмет взрывается в разные стороны
    /// сила прикладывается с сбоку (поезд несется)
    /// и модифицирует движения объектов на направление за опрделеннное время.
    /// а потом фейдится в "покой"
    /// </summary>
    public interface IForce
    {
        //Vector3 Direction;
        //float Duration;
    }

    public interface IDestructible
    {

    }

    //sequence of force impact
    //animationCurve, DOTWeen mmmm

    public class AnimatedDestructionSystem : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
