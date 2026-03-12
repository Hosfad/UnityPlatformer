using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons;

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level - 1);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting Game ...");
        Application.Quit();
    }
}
