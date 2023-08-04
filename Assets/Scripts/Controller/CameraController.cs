using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float dragSpeed = 1f;// 카메라 드래그 속도 조절

    private Vector3 dragOrigin; // 드래그 시작 위치를 저장하기 위한 변수

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 누르면 드래그 시작
        {
            dragOrigin = Input.mousePosition; // 유저가 누른 위치를 시작 위치로 지정한다.
            return;    
        }

        if (!Input.GetMouseButton(0)) return;  // 마우스 왼쪽 버튼을 누르고 있는 동안에만 처리

        // 드래그 이동 거리를 화면 좌표에서 뷰포트 좌표로 변환하는 함수이다.  
        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition );

        // pos의 x , y 에 각각 정해진 드래그 속도를 곱해 움직인다.
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);   // 월드 좌표를 기준으로 이동한다.
    }


}