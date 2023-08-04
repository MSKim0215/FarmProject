using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CreateCrops : UI_Popup
{
    private enum Buttons
    {
        Btn_Carrot,
        Btn_Cabbage
    }

    private Plowed targetPlowed;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        BindEvent(GetButton((int)Buttons.Btn_Carrot).gameObject, 
        (PointerEventData data) =>
        {   // 당근 심기
            OnCreate((Plowed.Plowed_Crops)(int)Buttons.Btn_Carrot);
        });

        BindEvent(GetButton((int)Buttons.Btn_Cabbage).gameObject,
        (PointerEventData data) =>
        {   // 양배추 심기
            OnCreate((Plowed.Plowed_Crops)(int)Buttons.Btn_Cabbage);
        });
    }

    public void SetTargetPlowed(Plowed target) => targetPlowed = target;

    private void OnCreate(Plowed.Plowed_Crops crops)
    {
        targetPlowed.Plant(crops);
    }
}
