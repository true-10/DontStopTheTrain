using System.Collections;
using System.Collections.Generic;
using True10.Managers;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    public class ChunkManager : DataManager<ObjectToScroll>
    {
        public override void Dispose()
        {
            Clear();
        }

        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
