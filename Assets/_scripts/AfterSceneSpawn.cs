using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterSceneSpawn : MonoBehaviour
{
    public int spawnSpot;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {   
        spawnSpot = PlayerPrefs.GetInt("Scene");
        if(spawnSpot == 1){
            player.transform.position = new Vector3(-12.0f, 0.0f, -19.0f);
            PlayerPrefs.SetInt("Sword", 1);
            PlayerPrefs.SetInt("Scene", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
