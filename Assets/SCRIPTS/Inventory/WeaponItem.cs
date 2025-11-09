using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [System.Serializable]
    public struct WeaponDamageProfile
    {
        public int stoneDamage;
        public int woodDamage;
        public int ironDamage;
        public int fleshDamage;

        public int GetDamageForTarget(TargetType type)
        {
            switch (type)
            {
                case TargetType.Stone: return stoneDamage;
                case TargetType.Wood: return woodDamage;
                case TargetType.Iron: return ironDamage;
                case TargetType.Flesh: return fleshDamage;
                default: return 0;
            }
        }
    }

    [System.Serializable]
    public class EffectWithChance
    {
        public StatusEffect effect;
        [Range(0f, 1f)]
        public float chance;
    }

    [CreateAssetMenu(fileName = "WeaponItem", menuName = "Scriptable Objects/WeaponItem")]
    public class WeaponItem : Item
    {
        public WeaponDamageProfile damageProfile;
        public List<EffectWithChance> effectsOnFlesh;
    }
}


