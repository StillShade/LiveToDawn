using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public DamageableObject currentTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageable = other.GetComponent<DamageableObject>();
        if (damageable != null)
        {
            Debug.Log("Вошли в триггер с целью: " + damageable.name);
            currentTarget = damageable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var damageable = other.GetComponent<DamageableObject>();
        if (damageable != null && currentTarget == damageable)
        {
            Debug.Log("Вышли из триггера с целью: " + damageable.name);
            currentTarget = null;
        }
    }
}
