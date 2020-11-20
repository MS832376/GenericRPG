using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip DesertTime, FoundSword, SwordMyth, TheDumps, Warning, whinykid, Zombie, Player;
    static AudioSource theNoise;

    void Start(){
        DesertTime = Resources.Load<AudioClip>("DesertTime");
        FoundSword = Resources.Load<AudioClip>("FoundSword");
        Warning = Resources.Load<AudioClip>("Warning");
        SwordMyth = Resources.Load<AudioClip>("SwordMyth");
        whinykid = Resources.Load<AudioClip>("whinykid");
        TheDumps = Resources.Load<AudioClip>("TheDumps");
        Zombie = Resources.Load<AudioClip>("ZombieHit");
        Player = Resources.Load<AudioClip>("PlayerHit");
        theNoise = GetComponent<AudioSource>();

    }
    public static void PlaySound(string clip){
        switch(clip){
        case "DesertTime":
            theNoise.PlayOneShot(DesertTime, 3.0f);
            break;
        case "FoundSword":
            theNoise.PlayOneShot(FoundSword, 3.0f);
            break;
        case "Warning":
            theNoise.PlayOneShot(Warning, 3.0f);
            break;
        case "SwordMyth":
            theNoise.PlayOneShot(SwordMyth, 3.0f);
            break;
        case "whinykid":
            theNoise.PlayOneShot(whinykid, 3.0f);
            break;
        case "TheDumps":
            theNoise.PlayOneShot(TheDumps, 3.0f);
            break;
        case "ZombieHit":
            theNoise.PlayOneShot(Zombie, 2.0f);
            break;
        case "PlayerHit":
            theNoise.PlayOneShot(Player, 3.0f);
            break;
        }
    }
    void Update(){
        if(theNoise == null){
            theNoise = GetComponent<AudioSource>();
        }
    }
}
