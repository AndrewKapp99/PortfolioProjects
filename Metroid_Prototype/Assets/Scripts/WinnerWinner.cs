using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerWinner : MonoBehaviour
{
    public GameObject ChickenDinner;

    void OnTriggerEnter(Collider other){
        ChickenDinner.SetActive(true);
    }
}
