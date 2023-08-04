using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plowed : MonoBehaviour
{
    public enum Plowed_Crops
    {
        Carrot = 100, Cabbage, None
    }

    private Transform planted_right, planted_left;        // �۹��� �ɴ� ��ġ
 
    public float growTime;                               // ���� ���� �ð�
    public bool isGrow = false;                          // ������ �Ϸ�Ǿ�����

    public DataContents.Stat Planted_Stat { private set; get; }     // �۹� ����
    public Plowed_Crops plowed_crops_type { set; get; } = Plowed_Crops.None;        // �۹� Ÿ��
    public Transform Planted_Right { set => planted_right = value; get => planted_right; }
    public Transform Planted_Left { set => planted_left = value; get => planted_left; }

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

        Planted_Stat = GetStat(crops);                  // �ش� Ÿ���� �۹� ���� ���� ��������

        string path = GetPath(plowed_crops_type);       // �ش� Ÿ���� �۹� ������ ��� ��������
        Managers.Resource.Instantiate(path, planted_left);
        Managers.Resource.Instantiate(path, planted_right);

        // UI ����
        Managers.UI.MakeWordSpaceUI<UI_GrowBar>(transform);
    }

    /// <summary>
    /// �۹��� ���� ������ ȣ�� �Լ�
    /// [Made_��μ� 23.08.04]
    /// </summary>
    /// <param name="crops">�۹� Ÿ��</param>
    private DataContents.Stat GetStat(Plowed_Crops crops) => Managers.Data.StatDict[(int)crops];

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
