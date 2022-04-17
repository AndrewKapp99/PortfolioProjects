using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public GameObject hinge;
    private Transform hingeTrans;
    public Vector3 rotateOpen, rotateClose;
    public GameObject Interaction;

    private bool inRange = false;
    private Vector3 rotateStart;
    public bool isOpen;

    void Start(){
        hingeTrans = hinge.GetComponentInChildren<Transform>();
    }

    void Update(){
        if(hingeTrans.rotation.eulerAngles == rotateOpen){
            rotateStart = rotateClose;
            isOpen = true;
        }
        if(hingeTrans.rotation.eulerAngles == rotateClose){
            rotateStart = rotateOpen;
            isOpen = false;
        }
        if(inRange && Input.GetKey(KeyCode.E)){
            HingeMove();
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player")
            inRange = true;

        Interaction.SetActive(true);
    }
    void OnTriggerExit(Collider other){
        inRange = false;

        Interaction.SetActive(false);
    }

    public void HingeMove(){
        hingeTrans.DORotate(rotateStart, 1f, RotateMode.Fast);
    }
}
