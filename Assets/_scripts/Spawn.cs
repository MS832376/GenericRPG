using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public int spawnSpot;
    public GameObject player;
    void Start()
    {
        spawnSpot = PlayerPrefs.GetInt("CameFrom");
        if(spawnSpot == 1){
            player.transform.position = new Vector3(5.0f, 0.0f, -37.0f);
        }else if(spawnSpot == 2){
            player.transform.position = new Vector3(-12.0f, 0.0f, -22.0f);
        }else if(spawnSpot == 3){
            player.transform.position = new Vector3(23.63f, 0.0f, -22.92f);
        }else{
            player.transform.position = new Vector3(5.0f, 0.0f, -20.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
