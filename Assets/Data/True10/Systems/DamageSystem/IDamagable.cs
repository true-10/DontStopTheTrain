namespace True10.DamageSystems.Damagables
{
    public interface IDamagable
    {
        IDamageCallback TakeDamage(IDamage damage);
    }

    public class Damagable : IDamagable
    {
        public IDamageCallback TakeDamage(IDamage damage)
        {
            var damageCallback = new DamageCallback();
            UnityEngine.Debug.Log("Taking damage");
            return damageCallback;
        }
    }
}
