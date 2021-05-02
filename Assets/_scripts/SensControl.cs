using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SensControl : MonoBehaviour
{
    public GameObject sensUI;
    public float sens;
    Text showText;
    // Start is called before the first frame update
    void Start()
    {
        sens = 0;
        showText = GetComponent<Text>();
        float f = PlayerPrefs.GetFloat("Sensitivity", 100.0f);
        showText.text = "Sens: " + f;
    }
    public void textUpdate(float value){
        sens = value;
        showText.text = "Sens: " + value;
    }
    public void changeScene(){
        if(sens != 0){
            PlayerPrefs.SetFloat("Sensitivity", sens);
            Debug.Log(PlayerPrefs.GetFloat("Sensitivity"));
        }
        sensUI.SetActive(false);
    }
}
