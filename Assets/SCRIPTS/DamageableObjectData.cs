using UnityEngine;

[CreateAssetMenu(fileName = "DamageableObjectData", menuName = "Scriptable Objects/DamageableObjectData")]
public class DamageableObjectData : ScriptableObject
{
    public TargetType targetType;
    public int maxHealth = 100;
    public Sprite sprite;
    // ����� �������� ������ ���������: ��������, ���, �������� � �.�.
}
