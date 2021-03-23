using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Editor vars
    // Private vars
    int currentSceneIndex = 0;
    // cached references

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current scene index " + currentSceneIndex);
        if(currentSceneIndex == 0){
            StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(3);
        LoadMainMenu();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadSceneByName(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadMainMenu(){
        LoadSceneByName("Game Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
