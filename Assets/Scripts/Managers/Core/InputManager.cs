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
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);      // ī�޶󿡼� ȭ����� ���콺 ��ġ�� ���̸� �߻�
            RaycastHit hit;         // ���̰� �浹�� ��ġ�� ������ ���� ����

            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Plowed", "Shop")))
            {   // ���� ĳ��Ʈ�� �߻��ϰ�, �浹�� ��쿡�� Debug.DrawRay�� ����

                //Vector3 rayStartPosition = Camera.main.transform.position;      // ���̸� �׷��� ���� ��ġ (ī�޶� ��ġ)
                //Vector3 rayEndPosition = hit.point;         // ���̸� �׷��� �� ��ġ (�浹 ����)    
                //float duration = 2f;        // ���̸� �׷��ֱ� ���� �ð� (�����Ӵ� ���̰� ������ �ð�)
                //Debug.DrawRay(rayStartPosition, rayEndPosition - rayStartPosition, Color.red, duration);        // Debug.DrawRay�� ����Ͽ� ���̸� �׸�

                // ��
                Plowed plowed = hit.collider.GetComponent<Plowed>();
                if(plowed != null)
                {
                    if (plowed.plowed_crops_type == Plowed.Plowed_Crops.None)
                    {   // �翡 �۹��� ���ٸ� 
                        UI_CreateCrops createCropsPopup = Object.FindObjectOfType<UI_CreateCrops>();                        // ���� �����ִ� �˾��� �ִ��� üũ�Ѵ�.
                        if (createCropsPopup == null) Managers.UI.ShowPopupUI<UI_CreateCrops>().SetTargetPlowed(plowed);    // ���� �����ִ� �˾��� ���ٸ� �˾��� Ȱ��ȭ�Ѵ�.
                        else Managers.UI.ClosePopupUI();                                                                    // ���� �����ִ� �˾��� �ִٸ� �˾��� ��Ȱ��ȭ�Ѵ�.
                    }
                    else
                    {   // �翡 �۹��� �ִٸ�
                        if (plowed.isGrow)
                        {   // ��� ������ ���¶�� ��Ȯ�Ѵ�.
                            Managers.Storage.ChangeStorage(plowed.plowed_crops_type);

                            plowed.isGrow = false;
                            plowed.plowed_crops_type = Plowed.Plowed_Crops.None;

                            Managers.Resource.Destroy(plowed.Planted_Left.GetChild(0).gameObject);
                            Managers.Resource.Destroy(plowed.Planted_Right.GetChild(0).gameObject);

                            Managers.Resource.Destroy(plowed.transform.Find("UI_GrowBar").gameObject);
                        }
                    }
                }

                // ����
                Shop shop = hit.collider.GetComponent<Shop>();
                if(shop != null)
                {
                    Managers.UI.ShowPopupUI<UI_ShopTrade>();
                }
            }
        }
    }
}
