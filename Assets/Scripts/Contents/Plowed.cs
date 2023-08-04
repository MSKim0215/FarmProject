using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plowed : MonoBehaviour
{
    public enum Plowed_Crops
    {
        Carrot, Cabbage, None
    }

    private Transform planted_right, planted_left;        // �۹��� �ɴ� ��ġ

    public Plowed_Crops plowed_crops_type { private set; get; } = Plowed_Crops.None;        // �۹� Ÿ��

    private void Awake()
    {
        planted_right = transform.Find("Planted_Right");
        planted_left = transform.Find("Planted_Left");
    }

    /// <summary>
    /// �۹��� �ɴ� �Լ�
    /// [Made_��μ� 23.08.03]
    /// </summary>
    public void Plant(Plowed_Crops crops)
    {
        if (plowed_crops_type != Plowed_Crops.None) return;
        plowed_crops_type = crops;

        string path = GetPath(plowed_crops_type);       // �ش� Ÿ���� �۹� ������ ��� ��������
        Managers.Resource.Instantiate(path, planted_left);
        Managers.Resource.Instantiate(path, planted_right);
    }

    /// <summary>
    /// �۹��� Ÿ�Կ� ���缭 ������ ��� ���� �Լ�
    /// [Made_��μ� 23.08.03]
    /// </summary>
    /// <param name="crops">�۹� Ÿ��</param>
    private string GetPath(Plowed_Crops crops)
    {
        switch(crops)
        {
            case Plowed_Crops.Carrot: return "Crops/Planted/PlantedCarrotPrefab";
            case Plowed_Crops.Cabbage: return "Crops/Planted/PlantedCabbagePrefab";
        }
        return null;
    }
}
