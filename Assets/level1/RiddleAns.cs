using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;



public class RiddleAns : MonoBehaviour {

    public GameObject minion;
    public GameObject riddle;
    public GameObject findMinion;
    public GameObject levelCompleted;
  
    public void TrueAns()
    {
        riddle.SetActive(false);
        levelCompleted.SetActive(true);

    }
    public void WrongAns()
    {
        riddle.SetActive(false);
        findMinion.SetActive(true);
       
    }
    public void GoToLevel(string gameLevel)
    {
        levelCompleted.SetActive(true);
        SceneManager.LoadScene(gameLevel);
    }
    public void GetMinion()
    {
        findMinion.SetActive(false);
        minion.SetActive(true);
    }
}


   
    