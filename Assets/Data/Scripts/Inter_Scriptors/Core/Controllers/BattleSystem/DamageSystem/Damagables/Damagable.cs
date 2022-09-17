using True10.DamageSystems.Damagables;

namespace Interceptors.DamageSystems.Damagables
{

    public class Damagable : IDamagable
    {
        public IDamageCallback TakeDamage(IDamage damage)
        {
            var damageCallback = new DamageCallback();
            //здесь прописываем нужную реализацию получения урона


            return damageCallback;
        }
    }


    public class DamageCallback : IDamageCallback
    {
        //public int UnitId;//кто получает урон
        //public int WeaponType;//???
        //урон? тип урона? дебафы?
        //крит удар?
        //public IDamage damage;?
        //public IDamagable damagable;?
        public IDamage Damage { get; set; }
    }
}
