using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    public Button level2Button;
    public Button level3Button;
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            return;
        }
        level2Button.interactable = GameState.GetLevelCompletedByName("Level1");
        level3Button.interactable = GameState.GetLevelCompletedByName("Level2");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMainMenu();
        }
        //Debug.Log(GameState.Level1);
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
        if (GameState.GetLevelCompletedByName("Level1"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
    
    public void PlayLevelThree()
    {
        if (GameState.GetLevelCompletedByName("Level2"))
        {
            SceneManager.LoadScene("Level3");
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


}
