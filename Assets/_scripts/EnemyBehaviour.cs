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
    public Collider zombBox;
    public bool dead;
    float dist;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        health = 100;

    }
    void OnTriggerEnter(Collider hitThis){

        if(hitThis.gameObject.tag == "DANGER"){
            health -= 50;
            SoundManagerScript.PlaySound("ZombieHit");
        }
        if(health <= 0){
            if(!dead){
                Movement.totalGot += 1;
                PlayerPrefs.SetInt("TotalGot", Movement.totalGot);
                Debug.Log(PlayerPrefs.GetInt("TotalGot", 0));
            }
            dead = true;
            anim.Play("death1");
            this.gameObject.tag = "deadZomb";
            Destroy(zombBox);
            StartCoroutine(ZombDeath());
            
        }
    }
    IEnumerator ZombDeath(){
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
        yield break;
    }
    void GetPlayer(){
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerTran = thePlayer.transform;
    }
    void Update(){
        if(!dead){
            if(playerTran != null){
                dist = Vector3.Distance(playerTran.position, transform.position);
                
                if(dist < inZone){
                    anim.Play("walk");
                    transform.LookAt(playerTran);
                    transform.position += transform.forward * Time.deltaTime;
                }else{
                    anim.Play("idle");
                }

            }else{
                Invoke("GetPlayer",1);
            }
        }
        
        
        
    }
}
