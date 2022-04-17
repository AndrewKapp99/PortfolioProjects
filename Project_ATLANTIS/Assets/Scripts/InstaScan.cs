using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaScan : MonoBehaviour
{
    private GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (Vector3.Distance(this.transform.position, items[i].transform.position) > 75)
                    items[i].GetComponent<ItemPing>().PingLong();
            }
        }
    }
}
