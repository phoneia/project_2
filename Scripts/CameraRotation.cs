using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private Transform obj;


    private void Update()
    {
        transform.RotateAround(obj.position, Vector3.up, 30 * Time.deltaTime);
        transform.LookAt(obj);
    }

}
