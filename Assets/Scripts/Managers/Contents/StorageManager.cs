using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager
{
    /// <summary>
    /// Key: �۹� �ε���, Value: ���� ���� ����
    /// [Made_��μ� 23.08.04]
    /// </summary>
    public Dictionary<int, int> StorageDict { private set; get; } = new Dictionary<int, int>();       // ���� ����� ��ųʸ�

    /// <summary>
    /// ����� ���� �Լ�
    /// [Made_��μ� 23.08.04]
    /// </summary>
    /// <param name="crops">�۹� Ÿ��</param>
    /// <param name="value">�߰��Ǵ� �۹� ����</param>
    public void ChangeStorage(Plowed.Plowed_Crops crops, int value = 8)
    {
        if(StorageDict.ContainsKey((int)crops))
        {   // �̹� ����� �����ϴ� �۹��̶��
            StorageDict[(int)crops] += value;       // ������ŭ �߰�
        }
        else
        {   // ����� ���� �۹��̶��
            StorageDict.Add((int)crops, value);     // ���ο� �۹� �߰�
        }
    }
}
