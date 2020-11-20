using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    void onTriggerEnter(Collider hitThis){
        if(hitThis.tag == "Enemy"){
            hitThis.GetComponent<IEnemy>().TakeDamage(50);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
