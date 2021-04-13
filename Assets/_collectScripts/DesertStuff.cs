using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertStuff : MonoBehaviour
{
    public GameObject zombCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("TotalGot", 0) == 7 && PlayerPrefs.GetInt("ZombCoin", 0) != 1){
            zombCoin.SetActive(true);
        }
        if(PlayerPrefs.GetInt("ZombCoin", 0) == 1){
            zombCoin.SetActive(false);
        }
    }
}
