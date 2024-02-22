using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public Transform target;
    public Vector3 offset;
    public bool isInverted = false;

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (isInverted == true)
        {
            mouseY = -mouseY;
        }

        Quaternion yRotation = Quaternion.AngleAxis(mouseX * turnSpeed, Vector3.up);
        Quaternion xRotation = Quaternion.AngleAxis(mouseY * turnSpeed, Vector3.right);

        offset = yRotation * xRotation * offset;

        transform.position = target.position + offset;

        transform.LookAt(target.position);
    }
}
