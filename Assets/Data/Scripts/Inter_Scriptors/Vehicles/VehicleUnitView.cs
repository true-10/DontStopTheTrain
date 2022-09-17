using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Interceptors.BattleSystem.Behaviours
{
    public enum RotationDirection
    {
        X, Y, Z
    }

    public class VehicleUnitView : MonoBehaviour
    {
        #region Visual
        [Header("wheels")]
        [SerializeField] private List<Transform> wheels;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float rotationAngle= 359f;
        //[SerializeField] private float rotationDuration= .5f;
        [SerializeField] private RotationDirection rotationDirection = RotationDirection.Z;
        #endregion

        #region Systens
        //контроллер? контроллер должен отдавать приказы! вынести и сделать наоборт.

        //анимация 
        /*
         анимации имена : атака таран вправо/влево/вперед/назад. аналогоично защита.

         */
        //

        #endregion

        public IBattleUnit BattleUnit { get; set; }
        #region vars

        private Vector3 rotDirVector = Vector3.zero;
        #endregion

        #region mono methods
        private void Start()
        {
            rotDirVector = Vector3.zero;
            switch(rotationDirection)
            {
                case RotationDirection.X:
                    rotDirVector = Vector3.right;
                    break;
                case RotationDirection.Y:
                    rotDirVector = Vector3.up;
                    break;
                case RotationDirection.Z:
                    rotDirVector = Vector3.forward;
                    break;
            }
            rotDirVector *= rotationAngle;
            /* foreach (var wheel in wheels)
             {
                 wheel.DOLocalRotate(rotDirVector, rotationDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
             }*/

            SetData();
        }

        private void Update()
        {
            foreach (var wheel in wheels)
            {
                wheel.Rotate(rotDirVector, rotationSpeed);
            }
        }
        #endregion

        public void SetData(/*data*/)
        {
            var damagable = new DamageSystems.Damagables.Damagable();
            BattleUnit = new BattleUnit(damagable);
        }

        public void LoadModels(/*Models*/)//перенести в загрузчик моделей, который будет меш выдавать или ГО
        {

        }

    }
}
