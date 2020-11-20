using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Goblins : MonoBehaviour, IEnemy
{
    public float health;
    public float maxHealth;
    void Start(){
        health = 100;
    }
    public void PerformAttack(){

    }
    public void TakeDamage(int amount){
        health -= amount;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
