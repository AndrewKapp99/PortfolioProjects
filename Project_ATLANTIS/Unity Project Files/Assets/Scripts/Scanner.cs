using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private Transform ScanTrig;
    [SerializeField] private Vector3 ChangeSPD;
    [SerializeField] private int MaxRadius;
    [SerializeField] private int StandardRadius;


    private float currentRadius;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            ExpandTrigger();
        }
        else
            currentRadius = StandardRadius;

        ScanTrig.transform.localScale = new Vector3(currentRadius, currentRadius, currentRadius);

    }

    private void ExpandTrigger()
    {
        currentRadius = Mathf.Lerp(currentRadius, MaxRadius, 0.2f);
    }
}
