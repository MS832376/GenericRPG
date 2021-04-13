﻿using System.Collections;
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
    public GameObject coinExp;
    public GameObject pauseUI;
    public float myHP;
    //public GameObject DangerSquare;
    public float multi = 1.0f;
    public float userSens = 100.0f;
    public bool combined = false;
    public bool haveSword;
    public int gotSword;

    public bool onGround;
    public bool attack;
    public bool STOPEVERYTHING;
    public static int totalGot;
    public static bool changeSens;
    public bool pressedE;
    public bool expCoins;

    void Start(){
        PlayerPrefs.SetInt("TotalGot", 0);
        pressedE = false;
        Cursor.lockState = CursorLockMode.Locked;
        myHP = 1.0f;
        HealthBar.SetHealthBarValue(myHP);
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        bigJump = new Vector3(0.0f, 2.5f, 0.0f);
        userSens = PlayerPrefs.GetFloat("Sensitivity", 100.0f);
        tryRotate = new Vector3(0, userSens*3, 0);
        if(PlayerPrefs.GetInt("Sword") == 1){
            haveSword = true;
            sword.SetActive(true);
            gotSword = 1;
        }else{
            haveSword = false;
            gotSword = 0;
            sword.SetActive(false);
        }
        attack = false;
        STOPEVERYTHING = false;
    }
    void OnCollisionStay(Collision hitThis){
        if(hitThis.gameObject.tag == "SwordDoor"){
            PlayerPrefs.SetInt("CameFrom", 1);
            SceneManager.LoadScene("GetTheSword"); 
        }
        if(hitThis.gameObject.tag == "BadDoor" && gotSword == 1){
            PlayerPrefs.SetInt("CameFrom", 2);
            PlayerPrefs.SetInt("TotalGot", 0);
            SceneManager.LoadScene("BadWorld");
        }
        if(hitThis.gameObject.tag == "BadDoor" && gotSword != 1){

        }
        if(hitThis.gameObject.tag == "BackTown"){
            SceneManager.LoadScene("Town");
        }
        
    }
    void OnCollisionEnter(Collision hitThis){
        if(hitThis.gameObject.tag == "Zombie"){
            myHP -= 0.2f;
            SoundManagerScript.PlaySound("PlayerHit");
            if(myHP <= 0.00f){
                Destroy(this.gameObject);
                SceneManager.LoadScene("YouDied");
            }
        }
        if(hitThis.gameObject.tag == "Ground"){
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            STOPEVERYTHING = false;
            onGround = true;

        }
        
    }
    void OnCollisionExit(Collision leaving){
        if(leaving.gameObject.tag == "Ground" && !STOPEVERYTHING){
            STOPEVERYTHING = true;
            rb.velocity += -(transform.up * multi * .35f);
        }
    }
    void OnTriggerEnter(Collider hitThis){
        if(hitThis.gameObject.tag == "SwordScene" && !haveSword){
            PlayerPrefs.SetInt("Scene", 1);
            haveSword = true;
            PlayerPrefs.SetInt("Sword", 1);
            SceneManager.LoadScene("SwordCutscene"); 
        }
        if(hitThis.gameObject.tag == "TownCoin"){
            PlayerPrefs.SetInt("townCoin", 1);
        }
        if(hitThis.gameObject.tag == "FreeCoin"){
            PlayerPrefs.SetInt("FreeCoin", 1);
            StartCoroutine(ExplainCoins());
        }
        if(hitThis.gameObject.tag == "zombieCoin"){
            PlayerPrefs.SetInt("ZombCoin", 1);
        }
        
    }

    void OnTriggerStay(Collider hitThis){
        if(hitThis.gameObject.tag == "NPC2"){
            if(pressedE){
                pressedE = false;
                SoundManagerScript.PlaySound("TheDumps");
            }
        }
        if(hitThis.gameObject.tag == "NPC"){
            if(pressedE){
                pressedE = false;
                SoundManagerScript.PlaySound("whinykid");
            }
        }
        if(hitThis.gameObject.tag == "SwordStory"){
            if(pressedE){
                pressedE = false;
                if(gotSword != 1){
                    SoundManagerScript.PlaySound("SwordMyth");
                }else{
                    SoundManagerScript.PlaySound("FoundSword");
                }   
            }      
        }
        if(hitThis.gameObject.tag == "Careful"){
            if(pressedE){
                pressedE = false;
                if(gotSword != 1){
                    SoundManagerScript.PlaySound("Warning");
                }else{
                    SoundManagerScript.PlaySound("DesertTime");
                }
            }
        }
    }

    // Update is called once per frame
    void Update(){
        if(rb == null){
            rb = GetComponent<Rigidbody>();
        }
        if(PlayerPrefs.GetInt("TotalGot") > 6){
            
            //SceneManager.LoadScene("GameOver");
        }
        if(myHP < 0.1f){
            Destroy(this.gameObject);
            SceneManager.LoadScene("YouDied");
        }
        HealthBar.SetHealthBarValue(myHP);
        if(Input.GetAxis("Mouse X") > 0){
            Quaternion rotate = Quaternion.Euler(tryRotate * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        }
        if(Input.GetAxis("Mouse X") < 0){
            Quaternion rotate = Quaternion.Euler(-tryRotate * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            multi = 4.0f;
        }
        if(rb.velocity == new Vector3(0.0f,0.0f,0.0f)){
            multi = 2.0f;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && gotSword == 1){
            if(sword.activeSelf == true){
                sword.SetActive(false);
            }else{
                sword.SetActive(true);
            }
        }
        if(Input.GetMouseButton(0) && gotSword == 1){
            anim.Play("Attack1");
            STOPEVERYTHING = true;
            //DangerSquare.SetActive(true);
            StartCoroutine(PleaseAttack());
        }
        if(Input.GetKeyDown(KeyCode.E)){
            pressedE = true;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseUI.SetActive(true);
            Time.timeScale = 0.0f; 
            
        }
        if(Input.GetKeyDown(KeyCode.Space) && onGround && !STOPEVERYTHING){
            onGround = false;
            if(multi == 2){
                rb.AddForce(transform.up * (multi*2.5f), ForceMode.Impulse);
                STOPEVERYTHING = true;
                onGround = false;
            }else{
                rb.AddForce(transform.up * (3.0f*2.5f), ForceMode.Impulse);
                STOPEVERYTHING = true;
                onGround = false;
            }
            anim.Play("Jump");
            StartCoroutine(PleaseJump());
        }
    }
    IEnumerator PleaseAttack(){
        yield return new WaitForSeconds(.48f);
        STOPEVERYTHING = false;
        //DangerSquare.SetActive(false);
        yield break;
    }
    IEnumerator ExplainCoins(){
        coinExp.SetActive(true);
        yield return new WaitForSeconds(10);
        coinExp.SetActive(false);
        yield break;
    }
    IEnumerator PleaseJump(){
        yield return new WaitForSeconds(1);
        while(!onGround){
            yield return new WaitForSeconds(.1f);
        }
        STOPEVERYTHING = false;
        yield break;
    }
    void FixedUpdate(){
        if(!STOPEVERYTHING){
            if(Input.GetKey(KeyCode.W)){
            if(multi == 2.0f && !combined){
                anim.Play("Walking");
            }
            if(multi > 2.0f && !combined){
                anim.Play("Running");
            }
            rb.velocity = (transform.forward * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                if(multi == 2.0f){
                    anim.Play("WalkingRF");
                }
                if(multi > 2){
                    anim.Play("RunningRF");
                }
                rb.velocity += (transform.right * multi);
            }else if(Input.GetKey(KeyCode.A)){
                combined = true;
                if(multi == 2.0f){
                    anim.Play("WalkingLF");
                }
                if(multi > 2){
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
            if(multi == 2 && !combined){
                anim.Play("WalkingBack");
            }
            if(multi > 2 && !combined){
                anim.Play("RunningBack");
            }
            rb.velocity = (-transform.forward * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                if(multi == 2.0f){
                    anim.Play("WalkingRB");
                }
                if(multi > 2){
                    anim.Play("RunningRB");
                }
                rb.velocity += (transform.right * multi);
            }else if(Input.GetKey(KeyCode.A)){
                combined = true;
                if(multi == 2.0f){
                    anim.Play("WalkingLB");
                }
                if(multi > 2){
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
            if(multi == 2.0f && !combined){
                anim.Play("WalkingRight");
            }
            if(multi > 2 && !combined){
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
            if(multi == 2.0f && !combined){
                anim.Play("WalkingLeft");
            }
            if(multi > 2 && !combined){
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
    }
    }
}
