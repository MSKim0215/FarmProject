using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStorageBox : StorageBox
{
    private enum Texts
    {
        Text_Value
    }

    public override void Init()
    {
        Bind<Text>(typeof(Texts));

        base.Init();

        SetCount();
    }

    protected override void SetIcon()
    {
        Sprite targetSprite = null;
        string path = "Sprites/VegetablesAndFruits";

        switch (cropType)
        {
            case Plowed.Plowed_Crops.Carrot: path += "/carrot_sprite"; break;
            case Plowed.Plowed_Crops.Cabbage: path += "/cabbage_sprite"; break;
        }

        targetSprite = Managers.Resource.Load<Sprite>(path);
        GetImage((int)Images.Img_Icon).sprite = targetSprite;
    }

    private void SetCount()
    {
        GetText((int)Texts.Text_Value).text = Managers.Storage.StorageDict[(int)cropType].ToString();
    }
}
