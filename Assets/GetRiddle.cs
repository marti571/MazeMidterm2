using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRiddle : MonoBehaviour {

    public GameObject getRiddle;
    public GameObject Riddle;
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            getRiddle.SetActive(true);
        }
    }

   public void OnRiddle()
   {
        getRiddle.SetActive(false);
        Riddle.SetActive(true);
    }
    
}
