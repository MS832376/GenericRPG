using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    //bool wasLocked = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(Input.GetKey(KeyCode.Space)){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //if(Input.GetMouseButtonUp(0)){
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
        
    }
    public void relockMouse(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
