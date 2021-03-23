using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // private vars
    int mainMenuIndex = 1;

    // cached references

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Menu update");
        // do some switching based on scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var backBtn = GameObject.Find("BTN-Back");
        var quitBtn = GameObject.Find("BTN-Quit");

        // If I'm on main menu (1), have a quit button
        if (currentSceneIndex == mainMenuIndex) {
            backBtn.SetActive(false);
            quitBtn.SetActive(true);
        // Otherwise, a back button
        } else {
            backBtn.SetActive(true);
            quitBtn.SetActive(false);
        }
    }
}
