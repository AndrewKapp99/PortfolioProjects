using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PursuitCam : MonoBehaviour
{
    public Transform Camera;
    public Transform PlayerMash;

    public void OnMove(InputValue input)
    {
        Camera.forward = Vector3.Lerp(Camera.forward, PlayerMash.forward, 0.5f);
    }
}
