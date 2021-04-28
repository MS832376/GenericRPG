using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collectTotals : MonoBehaviour
{
    public GameObject Total;
    Text totalText;
    public int totalCoins = 0;
    public int overall = 4;
    public GameObject Town;
    Text townText;
    public int townCoins = 0;
    public int townOver = 3;
    public GameObject Forest;
    Text forestText;
    public int forestCoins = 0;
    public int forestOver = 0;
    public GameObject Desert;
    Text desertText;
    public int desertCoins = 0;
    public int desertOver = 1;
    public GameObject Lake;
    Text lakeText;
    public int laketCoins = 0;
    public int lakeOver = 0;
    public GameObject Sword;
    Text swordText;
    public int swords = 0;
    public int swordOver = 2;
    public GameObject Shield;
    Text shieldText;
    public int shields = 0;
    public int shieldOver = 2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("collect script ran");
        townText = Town.GetComponent<Text>();
        forestText = Forest.GetComponent<Text>();
        desertText = Desert.GetComponent<Text>();
        lakeText = Lake.GetComponent<Text>();
        totalText = Total.GetComponent<Text>();
        swordText = Sword.GetComponent<Text>();
        shieldText = Shield.GetComponent<Text>();
        desertCoins = PlayerPrefs.GetInt("ZombCoin", 0);
        townCoins = PlayerPrefs.GetInt("townCoin", 0) + PlayerPrefs.GetInt("FreeCoin", 0) + PlayerPrefs.GetInt("GooseCoin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        shieldText.text = PlayerPrefs.GetInt("Shield", 0) + "/" + shieldOver;
        swordText.text = PlayerPrefs.GetInt("Sword", 0) + "/" + swordOver;
        townText.text = townCoins + "/" + townOver;
        forestText.text = forestCoins + "/" + forestOver;
        desertText.text = desertCoins + "/" + desertOver;
        lakeText.text = laketCoins + "/" + lakeOver;
        totalCoins = townCoins + forestCoins + desertCoins + laketCoins;
        totalText.text = totalCoins + "/" + overall;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }
}
