using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockScript : MonoBehaviour
{
    public GameObject Player;
    public string SkillName;
    [Header("UI")]
    public GameObject Jump, Dash;

    void OnTriggerEnter(Collider other)
         {
            StartCoroutine("UnlockSkill");
         }
     
     IEnumerator UnlockSkill() {
             yield return new WaitForSeconds(5);
            
             switch(SkillName) {
                 case "Jump": 
                     Player.GetComponent<CharacterMover>().canJump = true;
                     Jump.SetActive(true);
                     break;
                case "Dash":
                    Player.GetComponent<CharacterMover>().canDash = true;
                    Dash.SetActive(true);
                    break;
             }
         }
}
