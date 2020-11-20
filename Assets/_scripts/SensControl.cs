using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SensControl : MonoBehaviour
{
    public GameObject sensUI;
    Text showText;
    // Start is called before the first frame update
    void Start()
    {
        showText = GetComponent<Text>();
    }
    public void textUpdate(float value){
        PlayerPrefs.SetFloat("Sensitivity", value);
        showText.text = value + " sens";
    }
    public void changeScene(){
        sensUI.SetActive(false);
    }
}
