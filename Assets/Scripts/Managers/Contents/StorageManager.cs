using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager
{
    /// <summary>
    /// Key: 작물 인덱스, Value: 보유 중인 개수
    /// [Made_김민섭 23.08.04]
    /// </summary>
    public Dictionary<int, int> StorageDict { private set; get; } = new Dictionary<int, int>();       // 현재 저장고 딕셔너리

    /// <summary>
    /// 저장고 제어 함수
    /// [Made_김민섭 23.08.04]
    /// </summary>
    /// <param name="crops">작물 타입</param>
    /// <param name="value">추가되는 작물 개수</param>
    public void ChangeStorage(Plowed.Plowed_Crops crops, int value = 8)
    {
        if(StorageDict.ContainsKey((int)crops))
        {   // 이미 저장고에 존재하는 작물이라면
            StorageDict[(int)crops] += value;       // 수량만큼 추가
        }
        else
        {   // 저장고에 없는 작물이라면
            StorageDict.Add((int)crops, value);     // 새로운 작물 추가
        }
    }
}
