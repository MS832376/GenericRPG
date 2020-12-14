using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject controlUI;
    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void RestartGame(string scene){
        PlayerPrefs.SetInt("Sword", 0);
        PlayerPrefs.SetInt("CameFrom", 0);
        PlayerPrefs.SetInt("Scene", 0);
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
        SceneManager.LoadScene(scene);
    }
    public void QuitGame(string scene){
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }
    public void viewControl(){
        controlUI.SetActive(true);
    }
    public void stopControl(){
        controlUI.SetActive(false);
    }
}
