using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plowed : MonoBehaviour
{
    private Transform planted_right, planted_left;        // 작물을 심는 위치

    private void Awake()
    {
        planted_right = transform.Find("Planted_Right");
        planted_left = transform.Find("Planted_Left");
    }

    /// <summary>
    /// 작물을 심는 함수
    /// [Made_김민섭 23.08.03]
    /// </summary>
    public void Plant(string path)
    {
        Managers.Resource.Instantiate(path, planted_left);
        Managers.Resource.Instantiate(path, planted_right);
    }
}
