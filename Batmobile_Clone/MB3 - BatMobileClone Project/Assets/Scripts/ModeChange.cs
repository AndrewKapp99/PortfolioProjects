using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ModeChange : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera PursuitCam, BattleCam;
    private CharMove cm;
    private PursuitMode pm;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CharMove>();
        pm = GetComponent<PursuitMode>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, 0, 0);
    }

    public void OnSwitchMode(InputValue input)
    {
        float temp = input.Get<float>();
        if (temp > 0.5f)
        {
            cm.enabled = !cm.enabled;
            pm.enabled = !pm.enabled;
            SwitchCamera();
        }
    }

    private void SwitchCamera(){
        if(PursuitCam.Priority == 1){
            PursuitCam.Priority = 0;
            BattleCam.Priority = 1;
        }
        else if (BattleCam.Priority == 1) {
            BattleCam.Priority = 0;
            PursuitCam.Priority = 1;
        }
    }
}
