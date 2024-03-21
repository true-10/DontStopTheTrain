using System;
namespace True10.DamageSystems.Damagables
{
    public interface IDamageController
    {
        Action<IDamageCallback> OnTakeDamage { get; set; }
        void CalculateDamage(IDamage damage, IDamagable target);
    }


    public interface IDamageCallback
    {
        IDamage Damage { get; set; }
        //из какого оружия попали?
        //сколько урона?
        //какие дебафы?

    }

    public class DamageCallback : IDamageCallback
    {
        public IDamage Damage { get; set; }
    }
}