using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour {
    public Text coinsLeft;

    public int cur_coins = 0;
    public int max_coins = 0;

    public GameObject door;
    public GameObject winText;
    public float resetDelay;


    // Use this for initialization

    void Start () {
        door.SetActive(false);
        max_coins = cur_coins;
        UpdateUI();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateUI()
    {
        if(cur_coins > 0){
            coinsLeft.text = "Coins Left : " + cur_coins.ToString() + "/" + max_coins.ToString();
        }
        else if(cur_coins <= 0)
        {
            //door.SetActive(true);
            winText.SetActive(true);
            Time.timeScale = 0f;
            Invoke("Reset",resetDelay);


        }
    }
    public void Reset()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Menu");
    }
}
