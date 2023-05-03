using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void PlayLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
    
    public void PlayLevelThree()
    {
        SceneManager.LoadScene("Level3");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
