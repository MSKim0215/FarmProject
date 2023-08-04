using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plowed : MonoBehaviour
{
    public enum Plowed_Crops
    {
        Carrot = 100, Cabbage, None
    }

    private Transform planted_right, planted_left;        // 작물을 심는 위치
 
    public float growTime;                               // 현재 성장 시간

    public DataContents.Stat Planted_Stat { private set; get; }     // 작물 스탯
    public Plowed_Crops plowed_crops_type { private set; get; } = Plowed_Crops.None;        // 작물 타입

    private void Awake()
    {
        planted_right = transform.Find("Planted_Right");
        planted_left = transform.Find("Planted_Left");
    }

    /// <summary>
    /// 작물을 심는 함수
    /// [Made_김민섭 23.08.03]
    /// </summary>
    public void Plant(Plowed_Crops crops)
    {
        if (plowed_crops_type != Plowed_Crops.None) return;
        plowed_crops_type = crops;

        Planted_Stat = GetStat(crops);                  // 해당 타입의 작물 스탯 정보 가져오기

        string path = GetPath(plowed_crops_type);       // 해당 타입의 작물 프리팹 경로 가져오기
        Managers.Resource.Instantiate(path, planted_left);
        Managers.Resource.Instantiate(path, planted_right);

        // UI 생성
        Managers.UI.MakeWordSpaceUI<UI_GrowBar>(transform);
    }

    private DataContents.Stat GetStat(Plowed_Crops crops)
    {
        return Managers.Data.StatDict[(int)crops];
    }

    /// <summary>
    /// 작물의 타입에 맞춰서 프리팹 경로 리턴 함수
    /// [Made_김민섭 23.08.03]
    /// </summary>
    /// <param name="crops">작물 타입</param>
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
