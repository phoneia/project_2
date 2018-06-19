using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float speed;

    // 카메라 위치 값을 가지고 있는 offset 정보 (위치, 회전)
    public CameraOffset[] offset2;

    // 카메라 위치 상태
    public CameraViewRange camView = CameraViewRange.Normal;

    // 카메라의 케릭터 추적여부
    public CameraState camState = CameraState.Follow;

    // 이것 쓰이지 않는다.
    //public void Init(Transform player)
    //{
    //	this.player = player;
    //	transform.position = player.position + offset;
    //}

    void Update()
    {

        if (player == null)
            return;

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if ((int)camView > 0)
            {
                camView--;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if ((int)camView < 4)
            {
                camView++;
            }
        }


        switch (camState)
        {
            case CameraState.None:
                break;
            case CameraState.Normal:
                break;
            case CameraState.Follow:
                CamPosition();
                break;
            default:
                break;
        }

        if (camState == CameraState.Follow)
        {
            CamPosition();
        }
        else
        {
            camView = CameraViewRange.Normal;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 hor = Vector3.right * h;
            Vector3 ver = Vector3.forward * v;

            transform.Translate(Vector3.right * h * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * v * Time.deltaTime * speed, Space.World);

        }
    }

    public void CamPosition()
    {
        Vector3 camPos = player.position + offset2[(int)camView].offsetPos;

        transform.rotation = Quaternion.Euler(offset2[(int)camView].offsetRot);

        transform.position = Vector3.Lerp(
            transform.position, camPos, speed * Time.deltaTime);
    }

}
