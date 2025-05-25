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

    private void Start()
    {
        if (data == null)
        {
            Debug.LogError("DamageableObject: Data �� ���������!");
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
        Debug.Log($"�������� �����������: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // �������� ����������, ���, �������� ������� � �.�.
        Destroy(gameObject);
    }
}
