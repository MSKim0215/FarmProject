using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShopTrade : UI_Popup
{
    private enum GameObjects
    {
        Shop_Storage,
        Player_Storage
    }

    private List<StorageBox> storageBoxes = new List<StorageBox>();     // ���� ���� ������

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        // ���� ������ ���̺� ����
        for(int i = 100; i < Managers.Data.StatDict.Count + 100; i++)
        {
            GameObject prefab = Managers.Resource.Instantiate("UI/SubItem/StorageBox", GetObject((int)GameObjects.Shop_Storage).transform);
            StorageBox storage = prefab.GetComponent<StorageBox>();
            storage.Init((Plowed.Plowed_Crops)i);
            storageBoxes.Add(storage);
        }

        // ������ ������ ���̺� ����
        for(int i = 100; i < Managers.Storage.StorageDict.Count + 100; i++)
        {
            GameObject prefab = Managers.Resource.Instantiate("UI/SubItem/PlayerStorageBox", GetObject((int)GameObjects.Player_Storage).transform);
            PlayerStorageBox storage = prefab.GetComponent<PlayerStorageBox>();
            storage.Init((Plowed.Plowed_Crops)i);
        }
    }
}
