using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GrowBar : UI_Base
{
    private enum Images
    {
        Img_Background,
        Img_Main
    }

    private Camera gameViewCamera;
    private Transform parent;
    private Plowed plowed;

    public override void Init()
    {
        Bind<Image>(typeof(Images));

        gameViewCamera = GameObject.Find("GameView Camera").GetComponent<Camera>();
        parent = transform.parent;
        plowed = GetComponentInParent<Plowed>();

        SetImage();
    }

    private void SetImage()
    {
        Sprite targetSprite = null;
        string path = "Sprites/VegetablesAndFruits";

        switch (plowed.plowed_crops_type)
        {
            case Plowed.Plowed_Crops.Carrot: path += "/carrot_sprite"; break;
            case Plowed.Plowed_Crops.Cabbage: path += "/cabbage_sprite"; break;
        }

        targetSprite = Managers.Resource.Load<Sprite>(path);
        GetImage((int)Images.Img_Background).sprite = targetSprite;
        GetImage((int)Images.Img_Main).sprite = targetSprite;
    }

    private void Update()
    {
        // UI�� ���� ���� ī�޶� ���缭 ��ġ�� ������ �����Ѵ�.
        transform.position = parent.position + Vector3.up * 7f;
        transform.rotation = gameViewCamera.transform.rotation;

        // �۹� ���� �ð� Ÿ�̸� ���
        if(plowed.growTime < plowed.Planted_Stat.growTimeMax)
        {
            plowed.growTime += Time.unscaledDeltaTime;
            GetImage((int)Images.Img_Main).fillAmount = plowed.growTime / plowed.Planted_Stat.growTimeMax;

            //if(plowed.growTime >= plowed.Planted_Stat.growTimeMax)
            //{
            //    plowed.growTime = 0f;
            //}
        }
    }
}
