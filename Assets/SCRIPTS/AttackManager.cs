using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance { get; private set; }
    public AttackZone attackZone; // ������� ����� ���������

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AttackWithWeapon(Item weapon)
    {
        var target = attackZone.currentTarget;
        Debug.Log("������� ���������. ������� ����: " + (target != null ? target.name : "null"));
        if (target == null || weapon == null)
        {
            Debug.Log("��� ���� ��� ������ ��� �����!");
            return;
        }

        if (weapon is WeaponItem weaponItem)
        {
            int damage = weaponItem.damageProfile.GetDamageForTarget(target.data.targetType);
            Debug.Log($"������� {damage} ����� �� {target.name}");
            target.TakeDamage(damage);

            // �������� ����� � �.�.
        }
        else
        {
            // ����� ������������ ������ ��� ���������������
            Debug.LogWarning("������� ��������� ���������!");
        }
    }
}