using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public enum TargetType
{
    Stone,
    Wood,
    Iron,
    Flesh
}

public class DamageableObject : MonoBehaviour
{
    public DamageableObjectData data;

    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    public List<StatusEffect> activeEffects = new List<StatusEffect>();
    public bool isStunned = false;

    public void AddEffect(StatusEffect effect)
    {
        effect.ApplyEffect(this);
        activeEffects.Add(effect);
        StartCoroutine(RemoveEffectAfterDuration(effect));
    }

    private IEnumerator RemoveEffectAfterDuration(StatusEffect effect)
    {
        yield return new WaitForSeconds(effect.duration);
        effect.RemoveEffect(this);
        activeEffects.Remove(effect);
    }

    private void Start()
    {
        if (data == null)
        {
            Debug.LogError("DamageableObject: Data не назначена!");
            return;
        }

        currentHealth = data.maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && data.sprite != null)
        {
            spriteRenderer.sprite = data.sprite;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Здоровье уменьшилось: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Анимация разрушения, лут, удаление объекта и т.д.
        Destroy(gameObject);
    }
}
