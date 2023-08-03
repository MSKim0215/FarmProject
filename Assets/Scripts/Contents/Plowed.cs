using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plowed : MonoBehaviour
{
    private Transform planted_right, planted_left;        // �۹��� �ɴ� ��ġ

    private void Awake()
    {
        planted_right = transform.Find("Planted_Right");
        planted_left = transform.Find("Planted_Left");
    }

    /// <summary>
    /// �۹��� �ɴ� �Լ�
    /// [Made_��μ� 23.08.03]
    /// </summary>
    public void Plant(string path)
    {
        Managers.Resource.Instantiate(path, planted_left);
        Managers.Resource.Instantiate(path, planted_right);
    }
}
