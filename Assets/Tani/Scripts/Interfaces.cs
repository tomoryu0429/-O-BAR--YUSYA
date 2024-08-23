using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tani
{
    public interface IVisibilityControllable
    {
        public abstract void SetVisible(bool visibility);
        public abstract void SwitchVisibility();
    }
}



public static class DamageUtility
{
    public interface IDamageValueBase { }
    public interface IDamagable
    { 
        public abstract void OnTakeDamage(float damage, IDamageValueBase value = null);
    }
    public static void ApplyDamage(Object target, float damage, IDamageValueBase value = null)
    {
        if(target is IDamagable damagable)
        {
            ApplyDamage(damagable, damage, value);
        }
    }

    public static void ApplyDamage(IDamagable target,float damage,IDamageValueBase value = null)
    {
        target.OnTakeDamage(damage, value);
    }
}

