using System;
using System.Collections.Generic;

namespace DataContents
{
    [Serializable]
    public class Stat
    {
        public int index;                       // ���۹� �ε���
        public string objName;                  // ���۹� �̸�
        public int purchasePrice, salePrice;    // ���۹� ���Ű���, �ǸŰ���
        public float growTimeMax;               // ���۹� ����ð�
    }


    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> statList = new List<Stat>();      // �ҷ��� ���� ������

        /// <summary>
        /// �ҷ��� ���� �����͸� ��ųʸ��� �߰��ϴ� �Լ�
        /// [Made_��μ� 23.08.03]
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