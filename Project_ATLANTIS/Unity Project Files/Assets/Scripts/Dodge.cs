using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    [SerializeField] private float dodgeTime, cooldownTime;
    private float x, y, z;
    private CharMove cm;
    private Rigidbody rb;
    private Vector3 forceDirection, sourcePos;
    private bool dodge;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CharMove>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        dodge = cm.isDodgeing;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cm.isDodgeing = true;
        }

        if (dodge)
        {
            time += Time.deltaTime;
        }

        if (time >= dodgeTime)
        {
            cm.isDodgeing = false;
            time = 0f;
        }
    }
}
