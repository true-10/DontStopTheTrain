using True10.DamageSystems.Damagables;

namespace Interceptors.DamageSystems.Damagables
{

    public class Damagable : IDamagable
    {
        public IDamageCallback TakeDamage(IDamage damage)
        {
            var damageCallback = new DamageCallback();
            //����� ����������� ������ ���������� ��������� �����


            return damageCallback;
        }
    }


    public class DamageCallback : IDamageCallback
    {
        //public int UnitId;//��� �������� ����
        //public int WeaponType;//???
        //����? ��� �����? ������?
        //���� ����?
        //public IDamage damage;?
        //public IDamagable damagable;?
        public IDamage Damage { get; set; }
    }
}
