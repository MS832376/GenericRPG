using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{ 
    public Animator anim;
    public float inZone = 30.0f;
    [Header("Set Dynamically")]
    public GameObject thePlayer;
    public Transform playerTran;
    float dist;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;        
    }
    void GetPlayer(){
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerTran = thePlayer.transform;
    }
    void Update(){
        if(playerTran != null){
            dist = Vector3.Distance(playerTran.position, transform.position);
            if(dist < inZone){
                anim.Play("walk");
                transform.LookAt(playerTran);
                transform.position += transform.forward * Time.deltaTime;
            }
        }else{
            Invoke("GetPlayer",1);
        }
        if(health <= 0){
            Destroy(this);
        }
        
    }
}
