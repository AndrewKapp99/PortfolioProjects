using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITest : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    private Rigidbody rb;
    private TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tm = Text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tm.SetText(rb.velocity.magnitude + "");
    }
}
