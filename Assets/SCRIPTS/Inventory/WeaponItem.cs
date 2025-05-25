using UnityEngine;

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

[CreateAssetMenu(fileName = "WeaponItem", menuName = "Scriptable Objects/WeaponItem")]
public class WeaponItem : Item
{
    public WeaponDamageProfile damageProfile;
}
