using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public Vector3 jump;
    public Vector3 bigJump;
    public Vector3 tryRotate;
    public GameObject sword;
    public float multi = 1.0f;
    public float userSens = 100.0f;
    public bool combined = false;
    public bool haveSword;
    public int gotSword;

    public bool onGround;
    public bool attack;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        bigJump = new Vector3(0.0f, 2.5f, 0.0f);
        tryRotate = new Vector3(0, userSens*3, 0);
        if(PlayerPrefs.GetInt("Sword") == 1){
            haveSword = true;
            sword.SetActive(true);
            gotSword = 1;
        }else{
            haveSword = false;
            gotSword = 0;
        }
        attack = false;
    }
    void OnCollisionStay(Collision hitThis){
        if(hitThis.gameObject.tag == "Ground"){
            onGround = true;
        }
        if(hitThis.gameObject.tag == "SwordDoor"){
            SceneManager.LoadScene("GetTheSword");
            PlayerPrefs.SetInt("CameFrom", 1);
        }
        if(hitThis.gameObject.tag == "BadDoor"){
            SceneManager.LoadScene("BadWorld");
            PlayerPrefs.SetInt("CameFrom", 2);
        }
        if(hitThis.gameObject.tag == "TownWoods"){
            SceneManager.LoadScene("Town");
        }
        if(hitThis.gameObject.tag == "TownBad"){
            SceneManager.LoadScene("Town");
        }
    }
    void OnTriggerEnter(Collider hitThis){
        if(hitThis.gameObject.tag == "SwordScene" && !haveSword){
            PlayerPrefs.SetInt("Scene", 1);
            haveSword = true;
            PlayerPrefs.SetInt("Sword", 1);
            SceneManager.LoadScene("SwordCutscene"); 
        }
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetAxis("Mouse X") > 0){
            Quaternion rotate = Quaternion.Euler(tryRotate * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        }
        if(Input.GetAxis("Mouse X") < 0){
            Quaternion rotate = Quaternion.Euler(-tryRotate * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            multi = 4.0f;
        }else{
            multi = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.Tab) && gotSword == 1){
            if(sword.activeSelf == true){
                sword.SetActive(false);
            }else{
                sword.SetActive(true);
            }
        }
        if(Input.GetKey(KeyCode.E)){
            anim.Play("Attack1");
        }
    }
    void FixedUpdate(){
        
        if(Input.GetKey(KeyCode.W)){
            if(multi == 1.0f && !combined){
                anim.Play("Walking");
            }
            if(multi > 1.0f && !combined){
                anim.Play("Running");
            }
            rb.velocity = (transform.forward * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingRF");
                }
                if(multi > 1){
                    anim.Play("RunningRF");
                }
                rb.velocity += (transform.right * multi);
            }else if(Input.GetKey(KeyCode.A)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingLF");
                }
                if(multi > 1){
                    anim.Play("RunningLF");
                }
                rb.velocity += (-transform.right * multi);
            }else if(Input.GetKey(KeyCode.S)){
                anim.Play("Idle");
                rb.velocity = new Vector3(0.0f,0.0f,0.0f);
                
            }else{
                combined = false;
            }
        }else if(Input.GetKey(KeyCode.S)){
            if(multi == 1 && !combined){
                anim.Play("WalkingBack");
            }
            if(multi > 1 && !combined){
                anim.Play("RunningBack");
            }
            rb.velocity = (-transform.forward * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingRB");
                }
                if(multi > 1){
                    anim.Play("RunningRB");
                }
                rb.velocity += (transform.right * multi);
            }else if(Input.GetKey(KeyCode.A)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingLB");
                }
                if(multi > 1){
                    anim.Play("RunningLB");
                }
                rb.velocity += (-transform.right * multi);
            }else if(Input.GetKey(KeyCode.W)){
                anim.Play("Idle");
                rb.velocity = new Vector3(0.0f,0.0f,0.0f);  
            }else{
                combined = false;
            }
        }else if(Input.GetKey(KeyCode.D)){
            if(multi == 1.0f && !combined){
                anim.Play("WalkingRight");
            }
            if(multi > 1 && !combined){
                anim.Play("RunningRight");
            }
            rb.velocity = (transform.right * multi);
            if(Input.GetKey(KeyCode.A)){
                combined = true;
                anim.Play("Idle");
                rb.velocity = new Vector3(0.0f,0.0f,0.0f);
            }else{
                combined = false;
            }
        }else if(Input.GetKey(KeyCode.A)){
            if(multi == 1.0f && !combined){
                anim.Play("WalkingLeft");
            }
            if(multi > 1 && !combined){
                anim.Play("RunningLeft");
            }
            rb.velocity = (-transform.right * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                anim.Play("Idle");
                rb.velocity = new Vector3(0.0f,0.0f,0.0f);
            }else{
                combined = false;
            }
        }else{
            anim.Play("Idle");
        }
        
        
        /*if(Input.GetKey(KeyCode.Space) && onGround){
            onGround = false;
            if(multi == 1.0f){
                rb.velocity += jump;
            }
            if(multi > 1){
                rb.AddForce(bigJump,ForceMode.Impulse);
            }
            
        }*/
    }
}
