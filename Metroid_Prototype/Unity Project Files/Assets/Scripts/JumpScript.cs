using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public int JumpStr;
    public Rigidbody rb;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("SpacePressed");
            if(Physics.Raycast(transform.position, Vector3.down, 2)){
                Debug.Log("Trying to jump.");
                rb.AddForce(Vector3.up*JumpStr);
            }
        }
    }
}
