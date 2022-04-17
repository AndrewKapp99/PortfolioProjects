using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float MaxTrapTime;
    public GameObject Player; 
    public GameObject ResetPnt;
    private bool inTrap;
    public float timeInTrap;
    void Update()
    {
        if(inTrap)
            timeInTrap += Time.deltaTime;

        if(timeInTrap > MaxTrapTime){
            Player.GetComponent<CharacterMover>().Respawn(ResetPnt.transform.position);
            timeInTrap = 0;
            inTrap = false;
        }
    }

    void OnTriggerEnter(Collider other){
        inTrap = true;
        
    }

    void OnTriggerExit(Collider other){
        inTrap = false;
        timeInTrap = 0;
    }
}
