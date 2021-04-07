using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSequence : MonoBehaviour
{
    public Animator anim;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject person;
    public GameObject Sword;
    public bool run;
    public bool walk;
    public bool grabSword;
    public bool liftSword;
    // Start is called before the first frame update
    void Start()
    {
        cam2.SetActive(false);
        cam3.SetActive(false);
        run = true;
        walk = false;
        liftSword = false;
        grabSword = false;
        Sword.SetActive(false);
        PlayerPrefs.SetInt("Scene", 1);
        StartCoroutine(SceneThing());
    }

    IEnumerator SceneThing(){
        yield return new WaitForSeconds(3.5f);
        cam2.SetActive(true);
        cam1.SetActive(false);
        run = false;
        walk = true;
        yield return new WaitForSeconds(4);
        walk = false;
        grabSword = true;
        cam3.SetActive(true);
        cam2.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        grabSword = false;
        liftSword = true;
        Sword.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GetTheSword");
    }
    void OnTriggerEnter(Collider hitThis){
        if(hitThis.gameObject.tag == "walk"){
            run = false;
            walk = true;
        }
        if(hitThis.gameObject.tag == "grabsword"){
            walk = false;
            grabSword = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(run){
            anim.Play("Running");
            person.transform.Translate(Vector3.forward * Time.deltaTime * 3.5f);
        }
        if(walk){
            //cam2.SetActive(true);
            //cam1.SetActive(false);
            anim.Play("Walking");
            person.transform.Translate(Vector3.forward * Time.deltaTime * 2);
        }
        if(grabSword){
            //cam3.SetActive(true);
            //cam2.SetActive(false);
            anim.Play("grabsword");
        }if(liftSword){
            anim.Play("LiftSword");
        }
    }
}
