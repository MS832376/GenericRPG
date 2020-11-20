using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSquare : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DangerSquare;
    public GameObject player;
    public Vector3 playerPos;
    public Quaternion playerRot;
    void Awake(){
        Invoke("GetPlayer", 1);
    }
    void GetPlayer(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        playerRot = player.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if(playerPos != null){
            //DangerSquare.transform.rotation = playerRot;
            DangerSquare.transform.position = playerPos;
            GetPlayer();
        }else{
            Invoke("GetPlayer",1);
        }
    }
}
