using System;
using True10;
using True10.Interfaces;
using UnityEngine;

namespace DontStopTheTrain
{
    /// <summary>
    /// upgradablePart - � ������ �������� ����� �������� ������ � �������� ��� ������������� (��� �� ��� ��������)
    /// </summary>

    public class UpgradableView : AbstractGameLifeCycleBehaviour
    {
        public Action OnTryToUpgrade { get; set; }

        [SerializeField]
        private ClickAndMouseOverView _clickableView;


        public override void Initialize()
        {

        }
        public override void Dispose()
        {

        }

        public void TryToUpgrade()
        {

        }
    }
}
