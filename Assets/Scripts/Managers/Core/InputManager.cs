using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;    
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);      // 카메라에서 화면상의 마우스 위치로 레이를 발사
            RaycastHit hit;         // 레이가 충돌한 위치의 정보를 담을 변수

            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Plowed", "Shop")))
            {   // 레이 캐스트를 발사하고, 충돌한 경우에만 Debug.DrawRay를 생성

                //Vector3 rayStartPosition = Camera.main.transform.position;      // 레이를 그려줄 시작 위치 (카메라 위치)
                //Vector3 rayEndPosition = hit.point;         // 레이를 그려줄 끝 위치 (충돌 지점)    
                //float duration = 2f;        // 레이를 그려주기 위한 시간 (프레임당 레이가 유지될 시간)
                //Debug.DrawRay(rayStartPosition, rayEndPosition - rayStartPosition, Color.red, duration);        // Debug.DrawRay를 사용하여 레이를 그림

                // 밭
                Plowed plowed = hit.collider.GetComponent<Plowed>();
                if(plowed != null)
                {
                    if (plowed.plowed_crops_type == Plowed.Plowed_Crops.None)
                    {   // 밭에 작물이 없다면 
                        UI_CreateCrops createCropsPopup = Object.FindObjectOfType<UI_CreateCrops>();                        // 현재 열려있는 팝업이 있는지 체크한다.
                        if (createCropsPopup == null) Managers.UI.ShowPopupUI<UI_CreateCrops>().SetTargetPlowed(plowed);    // 현재 열려있는 팝업이 없다면 팝업을 활성화한다.
                        else Managers.UI.ClosePopupUI();                                                                    // 현재 열려있는 팝업이 있다면 팝업을 비활성화한다.
                    }
                    else
                    {   // 밭에 작물이 있다면
                        if (plowed.isGrow)
                        {   // 모두 성장한 상태라면 수확한다.
                            Managers.Storage.ChangeStorage(plowed.plowed_crops_type);

                            plowed.isGrow = false;
                            plowed.plowed_crops_type = Plowed.Plowed_Crops.None;

                            Managers.Resource.Destroy(plowed.Planted_Left.GetChild(0).gameObject);
                            Managers.Resource.Destroy(plowed.Planted_Right.GetChild(0).gameObject);

                            Managers.Resource.Destroy(plowed.transform.Find("UI_GrowBar").gameObject);
                        }
                    }
                }

                // 상점
                Shop shop = hit.collider.GetComponent<Shop>();
                if(shop != null)
                {
                    Managers.UI.ShowPopupUI<UI_ShopTrade>();
                }
            }
        }
    }
}
