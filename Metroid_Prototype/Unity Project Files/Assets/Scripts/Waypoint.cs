using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject Player;
    public GameObject Hinge;

    public void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<CharacterMover>().respawnPnt = transform.position;
        if(Hinge != null && Hinge.GetComponent<Door>().isOpen)
            Hinge.GetComponent<Door>().HingeMove();
    }
}
