using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] private float turnSpeed;

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        transform.rotation *= Quaternion.AngleAxis(horizontal * turnSpeed, Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(vertical * turnSpeed, Vector3.right);

        var angles = transform.localEulerAngles;
        angles.z = 0;

        var angle = transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        transform.localEulerAngles = angles;
    }
}
