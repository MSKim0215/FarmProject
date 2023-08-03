using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat: MonoBehaviour
{
    protected int index;                // ���۹� �ε���
    protected string objName;           // ���۹� �̸�
    protected int purchasePrice;        // ���۹� ���� ����
    protected int salePrice;            // ���۹� �Ǹ� ����
    protected float growTimeMax;        // ���۹� ���� �ð�

    public int Index { get => index; set => index = value; }                                // ���۹� �ε���
    public string ObjName { get => objName; set => objName = value; }                       // ���۹� �̸�
    public int PurchasePrice { get => purchasePrice; set => purchasePrice = value; }        // ���۹� ���� ����
    public int SalePrice { get => salePrice; set => salePrice = value; }                    // ���۹� �Ǹ� ����
    public float GrowTimeMax { get => growTimeMax; set => growTimeMax = value; }            // ���۹� ���� �ð�
}
