using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void changeScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public void newGame(string scene){
        PlayerPrefs.SetInt("Sword", 0);
        PlayerPrefs.SetInt("CameFrom", 0);
        PlayerPrefs.SetInt("Scene", 0);
        SceneManager.LoadScene(scene);
    }

}
