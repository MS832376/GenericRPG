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
    public int overall = 1;
    public GameObject Town;
    Text townText;
    public int townCoins = 0;
    public int townOver = 1;
    public GameObject Forest;
    Text forestText;
    public int forestCoins = 0;
    public int forestOver = 0;
    public GameObject Desert;
    Text desertText;
    public int desertCoins = 0;
    public int desertOver = 0;
    public GameObject Lake;
    Text lakeText;
    public int laketCoins = 0;
    public int lakeOver = 0;
    // Start is called before the first frame update
    void Start()
    {
        townText = Town.GetComponent<Text>();
        forestText = Forest.GetComponent<Text>();
        desertText = Desert.GetComponent<Text>();
        lakeText = Lake.GetComponent<Text>();
        totalText = Total.GetComponent<Text>();
        townCoins = PlayerPrefs.GetInt("townCoin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        townText.text = townCoins + "/" + townOver;
        forestText.text = forestCoins + "/" + forestOver;
        desertText.text = desertCoins + "/" + desertOver;
        lakeText.text = laketCoins + "/" + lakeOver;
        totalCoins = townCoins + forestCoins + desertCoins + laketCoins;
        totalText.text = totalCoins + "/" + overall;
    }
}
