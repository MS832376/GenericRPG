using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townStuff : MonoBehaviour
{
    public GameObject jumpCoin; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("townCoin", 0) == 1){
            jumpCoin.SetActive(false);
        }
    }
}
