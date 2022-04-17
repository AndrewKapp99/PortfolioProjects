using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPing : MonoBehaviour
{
    [SerializeField] private GameObject Icon;
    [SerializeField] private GameObject LongMarker;

    private bool active, longActive;
    private float time, longTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;
        }
        if (time > 3)
        {
            active = false;
            time = 0;
        }

        if (longActive)
        {
            longTime += Time.deltaTime;
        }
        if (longTime > 10)
        {
            longActive = false;
            longTime = 0;
        }

        Icon.SetActive(active);
        LongMarker.SetActive(longActive);
    }

    public void Ping()
    {
        active = true;
    }

    public void PingLong()
    {
        longActive = true;
    }
}
