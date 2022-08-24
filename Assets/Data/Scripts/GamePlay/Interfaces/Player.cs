using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    ///
    public interface IUnlock
    {
        int Id { get; }
        int MinimalLevelPlayer { get; }//minimal user player for unlocking this perk 

    }

    public interface IPerk
    {
        int UnlockId { get; }

    }

    public class PlayerInfo
    {
        public int ActionPoint { get; }
        public int Days { get; }//���� � ���� / ���-�� �����
        public int Expo { get; }
        public int Level { get; }
        public int Score { get; } //������� ����� ���������
        public List<IPerk> Perks { get; }
    }
}
