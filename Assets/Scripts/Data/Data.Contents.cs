using System;
using System.Collections.Generic;

namespace DataContents
{
    [Serializable]
    public class Stat
    {
        public int index;                       // 농작물 인덱스
        public string objName;                  // 농작물 이름
        public int purchasePrice, salePrice;    // 농작물 구매가격, 판매가격
        public float growTimeMax;               // 농작물 성장시간
    }


    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> statList = new List<Stat>();      // 불러온 스탯 데이터

        /// <summary>
        /// 불러온 스탯 데이터를 딕셔너리에 추가하는 함수
        /// [Made_김민섭 23.08.03]
        /// </summary>
        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> data = new Dictionary<int, Stat>();
            foreach(Stat stat in statList)
            {
                data.Add(stat.index, stat);
            }
            return data;
        }
    }
}