using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SensControl : MonoBehaviour
{
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
    public void changeScene(string scene){
        SceneManager.LoadScene(scene);
    }
}
