using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float dragSpeed = 1f;// ī�޶� �巡�� �ӵ� ����

    private Vector3 dragOrigin; // �巡�� ���� ��ġ�� �����ϱ� ���� ����

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� ������ �巡�� ����
        {
            dragOrigin = Input.mousePosition; // ������ ���� ��ġ�� ���� ��ġ�� �����Ѵ�.
            return;    
        }

        if (!Input.GetMouseButton(0)) return;  // ���콺 ���� ��ư�� ������ �ִ� ���ȿ��� ó��

        // �巡�� �̵� �Ÿ��� ȭ�� ��ǥ���� ����Ʈ ��ǥ�� ��ȯ�ϴ� �Լ��̴�.  
        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition );

        // pos�� x , y �� ���� ������ �巡�� �ӵ��� ���� �����δ�.
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);   // ���� ��ǥ�� �������� �̵��Ѵ�.
    }


}