using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject myCamera;
    [Header("Set Dynamically")]
    public GameObject thePlayer;
    public Vector3 playerPos;
    void Awake(){
        Invoke("GetPlayer", 1);
    }
    void GetPlayer(){
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerPos = thePlayer.transform.position;
    }
    void Update(){
        if(playerPos != null){
            myCamera.transform.position = playerPos + new Vector3(0,4f,-4f);
            GetPlayer();
        }else{
            Invoke("GetBall",1);
        }
    }
}
