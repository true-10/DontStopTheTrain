using DontStopTheTrain;
using System.Collections.Generic;

namespace True10.StaticData
{
    public abstract class StaticManager<T>
    {
        public IReadOnlyCollection<T> Datas { get; protected set; }

        public abstract void Initialize();

        public void Initialize(List<T> datas)
        {
            Datas = datas;
        }
    }
}
