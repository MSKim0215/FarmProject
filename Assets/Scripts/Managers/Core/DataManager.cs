using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    public Dictionary<Key, Value> MakeDict();       // ��ųʸ� ���� �Լ�
}

public class DataManager
{
    public Dictionary<int, DataContents.Stat> StatDict { private set; get; } = new Dictionary<int, DataContents.Stat>();        // ���� ������ ��ųʸ�

    /// <summary>
    /// ���� ���� �� �����͸� �ҷ����� �Լ�
    /// [Made_��μ� 23.08.03]
    /// </summary>
    public void Init()
    {
        
    }

    /// <summary>
    /// ������ Json ���� �ҷ����� �Լ�
    /// [Made_��μ� 23.08.03]
    /// </summary>
    /// <param name="path">���� ���</param>
    private Loader LoadJson<Loader, Key, Value>(string path) where Loader: ILoader<Key, Value>
    {
        return JsonUtility.FromJson<Loader>(Managers.Resource.Load<TextAsset>($"Data/{path}").text);
    }
}
