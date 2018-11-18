using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RiddleAns : MonoBehaviour {

    public GameObject minion;
    // Use this for initialization
    public void TrueAns(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }
    public void WrongAns()
    {
        minion.SetActive(true);
}
}
