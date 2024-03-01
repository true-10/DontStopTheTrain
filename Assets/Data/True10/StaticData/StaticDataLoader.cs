using UnityEngine;

namespace True10.StaticData
{
    public static class StaticDataLoader<T> where T : Object
    {
        public static T LoadStaticData(string path)
        {
            return Resources.Load<T>(path);
        }
    }
}
