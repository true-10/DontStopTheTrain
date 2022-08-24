using System;
using True10.DamageSystems.Damagables;

namespace Interceptors.DamageSystems.Damagables
{
    public class DamageController : IDamageController
    {
        public Action<IDamageCallback> OnTakeDamage { get; set; }

        public void CalculateDamage(IDamage damage, IDamagable target)
        {
            var damageCallback = target.TakeDamage(damage);
            OnTakeDamage?.Invoke(damageCallback);
        }
    }
}
