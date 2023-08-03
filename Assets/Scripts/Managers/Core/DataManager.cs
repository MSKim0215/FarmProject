using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    public Dictionary<Key, Value> MakeDict();       // 딕셔너리 생성 함수
}

public class DataManager
{
    public Dictionary<int, DataContents.Stat> StatDict { private set; get; } = new Dictionary<int, DataContents.Stat>();        // 스탯 데이터 딕셔너리

    /// <summary>
    /// 게임 시작 시 데이터를 불러오는 함수
    /// [Made_김민섭 23.08.03]
    /// </summary>
    public void Init()
    {
        
    }

    /// <summary>
    /// 데이터 Json 파일 불러오는 함수
    /// [Made_김민섭 23.08.03]
    /// </summary>
    /// <param name="path">파일 경로</param>
    private Loader LoadJson<Loader, Key, Value>(string path) where Loader: ILoader<Key, Value>
    {
        return JsonUtility.FromJson<Loader>(Managers.Resource.Load<TextAsset>($"Data/{path}").text);
    }
}
