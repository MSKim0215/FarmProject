using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageBox : UI_Base
{
    protected enum Buttons
    {
        Btn_Box
    }

    protected enum Images
    {
        Img_Icon
    }

    protected Plowed.Plowed_Crops cropType;
    protected DataContents.Stat cropStat;

    public void Init(Plowed.Plowed_Crops type)
    {
        cropType = type;
    }

    public override void Init()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        SetIcon();
    }

    protected virtual void SetIcon()
    {
        Sprite targetSprite = null;
        string path = "Sprites/SeedPacks";

        switch (cropType)
        {
            case Plowed.Plowed_Crops.Carrot: path += "/carrot_seedpack_sprite"; break;
            case Plowed.Plowed_Crops.Cabbage: path += "/cabbage_seedpack_sprite"; break;
        }

        targetSprite = Managers.Resource.Load<Sprite>(path);
        GetImage((int)Images.Img_Icon).sprite = targetSprite;
    }
}
