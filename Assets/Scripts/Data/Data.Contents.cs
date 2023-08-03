using System;

namespace DataContents
{
    [Serializable]
    public class Stat
    {
        public string objName;                  // 농작물 이름
        public int purchasePrice, salePrice;    // 농작물 구매가격, 판매가격
        public float growTimeMax;               // 농작물 성장시간
    }
}