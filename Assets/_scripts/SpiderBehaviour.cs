using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbody;
    public float inZone = 15.0f;
    public float attackZone = 2f;
    public Collider spidBox;
    public Transform allParts;
    

    [Header("Set Dynamically")]
    public GameObject thePlayer;
    public Transform playerTran;
    public bool threatened;
    public bool attacking;
    float dist;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        threatened = false;
        attacking = false;
        dist = 10000f;
    }
    void GetPlayer(){
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerTran = thePlayer.transform;
        //Debug.Log("Got PlayerTran");
    }
    void CheckDist(){
        dist = Vector3.Distance(playerTran.position, transform.position);
    }
    IEnumerator PleaseAttack(){
        yield return new WaitForSeconds(1f);
        attacking = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(!attacking){
            if(playerTran == null){
                GetPlayer();
            }else{
                CheckDist();
                if(dist <= attackZone){
                    attacking = true;
                    anim.Play("Attack");
                    allParts.LookAt(playerTran);
                    transform.LookAt(playerTran);
                    StartCoroutine(PleaseAttack());
                }else if(dist > attackZone && threatened){
                    anim.Play("Walking");
                    allParts.LookAt(playerTran);
                    transform.LookAt(playerTran);
                    spidBox.transform.position += transform.forward * Time.deltaTime;
                }else if(dist <= inZone && !threatened){
                    threatened = true;
                    anim.Play("Walking");
                    allParts.LookAt(playerTran);
                    transform.LookAt(playerTran);
                    spidBox.transform.position += transform.forward * Time.deltaTime;
                }else{
                    threatened = false;
                    anim.Play("Idle");
                }
                if(dist > inZone){
                    threatened = false;
                }    
            }
        }
        
    }
}
