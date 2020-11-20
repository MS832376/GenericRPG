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
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;        
    }
    void OnTriggerEnter(Collider hitThis){

        if(hitThis.gameObject.tag == "DANGER"){
            health -= 50;
            SoundManagerScript.PlaySound("ZombieHit");
        }
        if(health <= 0){
            anim.Play("death1");
            Destroy(this.gameObject);
            Movement.totalGot += 1;
            PlayerPrefs.SetInt("TotalGot", Movement.totalGot);
            Debug.Log(Movement.totalGot);
        }
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
            }else if(dist <= 3){
                anim.Play("attack1");   
            }else{
                anim.Play("idle");
            }
        }else{
            Invoke("GetPlayer",1);
        }
        
        
    }
}
