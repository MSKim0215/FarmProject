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

            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Plowed")))
            {   // ���� ĳ��Ʈ�� �߻��ϰ�, �浹�� ��쿡�� Debug.DrawRay�� ����

                Vector3 rayStartPosition = Camera.main.transform.position;      // ���̸� �׷��� ���� ��ġ (ī�޶� ��ġ)
                Vector3 rayEndPosition = hit.point;         // ���̸� �׷��� �� ��ġ (�浹 ����)    
                float duration = 2f;        // ���̸� �׷��ֱ� ���� �ð� (�����Ӵ� ���̰� ������ �ð�)
                Debug.DrawRay(rayStartPosition, rayEndPosition - rayStartPosition, Color.red, duration);        // Debug.DrawRay�� ����Ͽ� ���̸� �׸�

                Plowed plowed = hit.collider.GetComponent<Plowed>();
                if (plowed?.plowed_crops_type == Plowed.Plowed_Crops.None)
                {   // plowed Ŭ������ �����ϰ� Ÿ���� ���� ���¶��
                    plowed?.Plant(Plowed.Plowed_Crops.Carrot);      // ����� �ɴ´�.
                }           
            }
        }
    }
}
