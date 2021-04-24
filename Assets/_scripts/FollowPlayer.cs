using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject myCamera;
    public GameObject target;
    [Header("Set Dynamically")]
    public GameObject thePlayer;
    public Vector3 playerPos;
    public Quaternion playerRot;
    public Quaternion lookUp;
    public Quaternion lookDown;

    void Awake(){
        Invoke("GetPlayer", 1);
    }
    void Start(){
        lookUp = Quaternion.Euler(new Vector3(PlayerPrefs.GetFloat("Sensitivity", 100.0f)*3, 0, 0) * Time.deltaTime);
        lookDown = Quaternion.Euler(-(new Vector3(PlayerPrefs.GetFloat("Sensitivity", 100.0f)*3, 0, 0)) * Time.deltaTime);
    }
    void GetPlayer(){
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerPos = thePlayer.transform.position;
        playerRot = thePlayer.transform.rotation;
    }
    void FixedUpdate(){
        if(playerPos != null){
            myCamera.transform.rotation = playerRot;
            myCamera.transform.position = playerRot * new Vector3(0.0f,2.0f,-2.0f) + playerPos;
            myCamera.transform.LookAt(target.transform);
            
            GetPlayer();
        }else{
            Invoke("GetPlayer",1);
        }
    }
}
