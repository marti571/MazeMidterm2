using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour {

    public AudioClip coin;
    AudioSource aScorce;
    GameObject obj;

    GameManagerScript GMS;
    // Use this for initialization
    void Awake()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.cur_coins++;
    }

    void Start () {
        obj = GameObject.Find("AudioObject");
        if (obj != null)
        {
            aScorce = obj.GetComponent<AudioSource>(); // get component once @ Start more efficient.
          
        }

    }
	
	// Update is called once per frame
	void Update () {
    
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "midtermcharacter")
        {
            aScorce.clip = coin; //once the coin is destroyed, make coin sound
            aScorce.Play();
            Destroy(gameObject);
            GMS.cur_coins--;
            GMS.UpdateUI();

        }
    }
}
