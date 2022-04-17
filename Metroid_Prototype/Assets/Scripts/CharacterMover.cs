using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMover : MonoBehaviour
{
    [Header("Management")]
    [SerializeField] private Player player;
    public CharacterController controller;
    public GameObject PlayerObj;
    public Transform cam; 
    [Header("Movement")]
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    public bool canJump = false;
    public float JumpForce;
    public float DashSpd;
    public float DashTime;
    public bool canDash;

    

    [Header("Misc")]
    public Vector3 respawnPnt;

    Vector3 moveDirection;
    private float gravity = 2f;
    public float time = 0;

    void Start(){
        respawnPnt = transform.position;
    }

    void FixedUpdate(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        Vector3 transDirection = transform.TransformDirection(direction);
        Vector3 flatMove = speed*Time.deltaTime*transDirection;

        moveDirection = new Vector3(flatMove.x, moveDirection.y, flatMove.z);

        if(PlayerJumped){
            moveDirection.y = JumpForce;
        }
        else if(controller.isGrounded){
            moveDirection.y = 0f;
        }
        else{
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if(playerDashed){
            moveDirection += new Vector3(moveDirection.x, 0f, moveDirection.z) * DashSpd;
        }

        if(transform.position.y < -2){
            Respawn(respawnPnt);
        }

        controller.Move(moveDirection);
    }

    private bool PlayerJumped => controller.isGrounded && Input.GetKey(KeyCode.Space) && canJump;
    private bool playerDashed => Input.GetKey(KeyCode.Q) && canDash && time <= DashTime;

    public void Respawn(Vector3 pos){
        controller.enabled = false;
        transform.position = pos;
        controller.enabled = true;
    }
}
