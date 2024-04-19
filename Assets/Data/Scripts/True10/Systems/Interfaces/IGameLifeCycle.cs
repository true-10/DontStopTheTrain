using System;

namespace True10.Interfaces
{

    public interface IGameLifeCycle
    {
       // Action OnInit { get; set;}

        void Initialize();
        void Dispose();
    }
}
