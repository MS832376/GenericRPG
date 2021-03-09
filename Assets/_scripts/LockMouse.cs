using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    public static bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && !paused){
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }else if(!paused){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
