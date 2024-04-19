using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.MiniGames
{
    /// <summary>
    /// disassembling device in searching broken part
    /// </summary>
    public class MG_Disassembly : MonoBehaviour
    {

    }

    public interface IPart : IEntity
    {
        List<IScrew> Screws { get ; set; }
        void Detach();
    }

    //����/�����
    public interface IScrew //: IPart
    {

    }

    //��������
    public interface ISticker //: IPart
    {

    }

    public interface ITool : IEntity
    {

    }
    
    public interface IUnit : IEntity
    {

    }

    public interface IScrewDriver : ITool
    {

    }
}
