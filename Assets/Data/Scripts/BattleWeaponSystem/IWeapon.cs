using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.BattleSystem
{
    public class WeaponData
    {
        public int Damage;
        public float Cooldown;
        public float ReloadCooldown;

    }


    public interface IWeapon
    {
        int Type { get; }
    }

    public interface IDamage
    {
        int Type { get; }

    }


    public interface IDamagable
    {

    }
}

