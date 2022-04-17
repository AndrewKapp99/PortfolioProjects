using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    private CharMove cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CharMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cm.isSprinting = !(cm.isSprinting);
        }
    }
}
