using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour
{
    public GameObject allthetext;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = allthetext.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Start");
        }

    }
    void FixedUpdate(){
        rb.velocity = transform.up * 20.0f;

    }
}
