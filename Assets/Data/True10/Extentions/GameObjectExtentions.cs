namespace True10.Extentions
{
    using UnityEngine;

    public static class GameObjectExtentions
    {
        public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }

        public static T OrNull<T>(this T obj) where T : Object
        {
            return obj ? obj : null;
        }


        public static void DestroyChildren(this GameObject gameObject)
        {
            gameObject.transform.DestroyChildren();
        }


        public static void DestroyVFXGameObject(this GameObject vfx)
        {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            GameObject.Destroy(vfx, ps.main.duration);
        }
    }
}
