using System;

namespace DataContents
{
    [Serializable]
    public class Stat
    {
        public string objName;                  // ���۹� �̸�
        public int purchasePrice, salePrice;    // ���۹� ���Ű���, �ǸŰ���
        public float growTimeMax;               // ���۹� ����ð�
    }
}