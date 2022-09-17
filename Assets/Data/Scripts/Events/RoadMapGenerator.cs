using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events //в левел скролл систем?
{
    /// <summary>
    /// Генерирует путь от станции до станции
    /// визуальный ряд
    /// события на отправление?
    /// собатия на ход (какие поломки и прочее)
    /// собатия на смену хода (закат/рассвет, смена локации, мега авария и прочее)
    /// события на прибытие
    /// собатия на станции
    /// </summary>
    public class RoadMapGenerator : MonoBehaviour
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

    public class RoadMapData
    {
        public List<RoadMapEvent> events;
    }

    public class RoadMapEvent
    {
        public int id;

    }
}
