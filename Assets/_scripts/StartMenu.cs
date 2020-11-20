using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject sensUI;
    public GameObject controlUI;
    public void changeScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public void newGame(string scene){
        PlayerPrefs.SetInt("Sword", 0);
        PlayerPrefs.SetInt("CameFrom", 0);
        PlayerPrefs.SetInt("Scene", 0);
        SceneManager.LoadScene(scene);
    }
    public void changeSens(){
        sensUI.SetActive(true);
    }
    public void viewControl(){
        controlUI.SetActive(true);
    }
    public void stopControl(){
        controlUI.SetActive(false);
    }

}
