using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public Vector3 jump;
    public Vector3 bigJump;
    public Vector3 tryRotate;
    public float multi = 1.0f;
    public float userSens = 100.0f;
    public bool combined = false;
    public bool onGround;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        bigJump = new Vector3(0.0f, 2.5f, 0.0f);
        tryRotate = new Vector3(0, userSens*3, 0);
    }
    void OnCollisionStay(Collision hitThis){
        if(hitThis.gameObject.tag == "Ground"){
            onGround = true;
        }    
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.W)){
            if(multi == 1.0f && !combined){
                anim.Play("Walking");
            }
            if(multi > 1.0f && !combined){
                anim.Play("Running");
            }
            transform.Translate(Vector3.forward * Time.deltaTime * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingRF");
                }
                if(multi > 1){
                    anim.Play("RunningRF");
                }
                transform.Translate(Vector3.right * Time.deltaTime * multi);
            }else if(Input.GetKey(KeyCode.A)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingLF");
                }
                if(multi > 1){
                    anim.Play("RunningLF");
                }
                transform.Translate(Vector3.left * Time.deltaTime * multi);
            }else if(Input.GetKey(KeyCode.S)){
                anim.Play("Idle");
                transform.Translate(Vector3.back * Time.deltaTime * multi);
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
            transform.Translate(Vector3.back * Time.deltaTime * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingRB");
                }
                if(multi > 1){
                    anim.Play("RunningRB");
                }
                transform.Translate(Vector3.right * Time.deltaTime * multi);
            }else if(Input.GetKey(KeyCode.A)){
                combined = true;
                if(multi == 1.0f){
                    anim.Play("WalkingLB");
                }
                if(multi > 1){
                    anim.Play("RunningLB");
                }
                transform.Translate(Vector3.left * Time.deltaTime * multi);
            }else if(Input.GetKey(KeyCode.W)){
                anim.Play("Idle");
                transform.Translate(Vector3.forward * Time.deltaTime * multi);
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
            transform.Translate(Vector3.right * Time.deltaTime * multi);
            if(Input.GetKey(KeyCode.A)){
                combined = true;
                anim.Play("Idle");
                transform.Translate(Vector3.left * Time.deltaTime * multi);
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
            transform.Translate(Vector3.left * Time.deltaTime * multi);
            if(Input.GetKey(KeyCode.D)){
                combined = true;
                anim.Play("Idle");
                transform.Translate(Vector3.right * Time.deltaTime * multi);
            }else{
                combined = false;
            }
        }else{
            anim.Play("Idle");
        }
        if(Input.GetAxis("Mouse X") > 0){
            Quaternion rotate = Quaternion.Euler(tryRotate * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        }
        if(Input.GetAxis("Mouse X") < 0){
            Quaternion rotate = Quaternion.Euler(-tryRotate * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        }
        if(Input.GetKey(KeyCode.Space) && onGround){
            onGround = false;
            if(multi == 1.0f){
                rb.AddForce(jump, ForceMode.Impulse);
            }
            if(multi > 1){
                rb.AddForce(bigJump, ForceMode.Impulse);
            }
            
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            multi = 3.0f;
        }else{
            multi = 1.0f;
        }
    }
}
