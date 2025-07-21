using System.Collections.Generic;
using UnityEngine;

public class DamageableObjectFactory : MonoBehaviour
{
    public static DamageableObjectFactory Instance { get; private set; }

    public GameObject damageablePrefab;
    public DamageableObjectData[] allTypes; // ������� � ����������

    private Dictionary<TargetType, List<DamageableObjectData>> typeToDataList;

    private void Awake()
    {
        // Singleton �������������
        if (Instance == null)
        {
            Instance = this;
            // ���� ������, ����� ������� �� ������������ ��� ����� ����:
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // ������������� �������
        typeToDataList = new Dictionary<TargetType, List<DamageableObjectData>>();
        foreach (var data in allTypes)
        {
            if (!typeToDataList.ContainsKey(data.targetType))
                typeToDataList[data.targetType] = new List<DamageableObjectData>();
            typeToDataList[data.targetType].Add(data);
        }
    }

    // ��������� �������
    public GameObject CreateRandom(TargetType type, Vector3 position)
    {
        if (!typeToDataList.ContainsKey(type) || typeToDataList[type].Count == 0)
        {
            Debug.LogError("��� ������ ��� ����: " + type);
            return null;
        }

        var list = typeToDataList[type];
        var data = list[Random.Range(0, list.Count)];

        var obj = Instantiate(damageablePrefab, position, Quaternion.identity);
        var damageable = obj.GetComponent<DamageableObject>();
        damageable.data = data;
        return obj;
    }

    // ����������� ������� (�� �������)
    public GameObject CreateByIndex(TargetType type, int index, Vector3 position)
    {
        if (!typeToDataList.ContainsKey(type) || typeToDataList[type].Count == 0)
        {
            Debug.LogError("��� ������ ��� ����: " + type);
            return null;
        }

        var list = typeToDataList[type];
        if (index < 0 || index >= list.Count)
        {
            Debug.LogError("������ ��� ��������� ��� ����: " + type);
            return null;
        }

        var data = list[index];

        var obj = Instantiate(damageablePrefab, position, Quaternion.identity);
        var damageable = obj.GetComponent<DamageableObject>();
        damageable.data = data;
        return obj;
    }
}
