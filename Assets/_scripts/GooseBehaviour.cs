using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseBehaviour : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbody;
    public float inZone = 15.0f;
    public float runZone = 7.5f;
    public Collider goosBox;
    

    [Header("Set Dynamically")]
    public GameObject thePlayer;
    public Transform playerTran;
    public GameObject gooseCoin;
    public Transform coinTran;
    public bool threatened;
    public bool running;
    public bool coinDropped;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        gooseCoin = GameObject.FindGameObjectWithTag("GooseCoin");
        if(PlayerPrefs.GetInt("GooseCoin", 0) == 1){
            coinDropped = true;
            gooseCoin.SetActive(false);
        }else{
            coinDropped = false;
            gooseCoin.SetActive(false);
        }
        threatened = false;
        running = false;
        dist = 10000f;
    }
    void OnCollisionEnter(Collision hitThis){
        if(hitThis.gameObject.tag == "Player" && !coinDropped){
            gooseCoin.SetActive(true);
            coinDropped = true; 
        }
    }
    void GetPlayer(){
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerTran = thePlayer.transform;
    }
    void GetCoin(){
        gooseCoin = GameObject.FindGameObjectWithTag("GooseCoin");
        coinTran = gooseCoin.transform;
    }
    void CheckDist(){
        dist = Vector3.Distance(playerTran.position, transform.position);
    }
    IEnumerator PleaseWait(){
        yield return new WaitForSeconds(2.0f);
        threatened = false;
        yield break;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!coinDropped){
            gooseCoin.transform.position = this.transform.position;
        }
        if(playerTran == null){
            
            GetPlayer();
            CheckDist();

        }else{
            if(dist <= runZone){
                running = true;
                anim.Play("threatenedRun");
                if(!threatened){
                    threatened = true;
                    SoundManagerScript.PlaySound("GooseClose");
                    StartCoroutine(PleaseWait());
                }
                transform.LookAt(playerTran);
                this.transform.Rotate(0f, 45f, 0f, Space.World);
                goosBox.transform.position += transform.right * 5f * Time.deltaTime;
            }else if(running && dist > runZone){
                anim.Play("threatenedRun");
                if(!threatened){
                    threatened = true;
                    SoundManagerScript.PlaySound("GooseClose");
                    StartCoroutine(PleaseWait());
                }
                if(dist > 5f){
                    running = false;
                }
                transform.LookAt(playerTran);
                this.transform.Rotate(0f, 45f, 0f, Space.World);
                goosBox.transform.position += transform.right * 4.5f * Time.deltaTime;
            }else if(!running && dist <= inZone){
                
                anim.Play("threatened");
                if(!threatened){
                    threatened = true;
                    SoundManagerScript.PlaySound("GooseClose");
                    StartCoroutine(PleaseWait());
                }
                transform.LookAt(playerTran);
                this.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
            }else{
                threatened = false;
                anim.Play("idle");
                
            }
            CheckDist();
        }
        
    }
}
