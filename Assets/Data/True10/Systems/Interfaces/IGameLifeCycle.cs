using System;

public interface IGameLifeCycle
{
    Action OnInit { get; set;}

    void Init();
    void Dispose();
}
