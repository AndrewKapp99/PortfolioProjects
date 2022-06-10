using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnchor : MonoBehaviour
{
    [SerializeField] private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
    }
}
