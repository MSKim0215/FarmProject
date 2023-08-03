using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat: MonoBehaviour
{
    protected int index;                // 농작물 인덱스
    protected string objName;           // 농작물 이름
    protected int purchasePrice;        // 농작물 구매 가격
    protected int salePrice;            // 농작물 판매 가격
    protected float growTimeMax;        // 농작물 성장 시간

    public int Index { get => index; set => index = value; }                                // 농작물 인덱스
    public string ObjName { get => objName; set => objName = value; }                       // 농작물 이름
    public int PurchasePrice { get => purchasePrice; set => purchasePrice = value; }        // 농작물 구매 가격
    public int SalePrice { get => salePrice; set => salePrice = value; }                    // 농작물 판매 가격
    public float GrowTimeMax { get => growTimeMax; set => growTimeMax = value; }            // 농작물 성장 시간
}
