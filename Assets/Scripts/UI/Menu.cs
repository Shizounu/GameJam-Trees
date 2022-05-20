using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //START
    public void start()
    {
        SceneManager.LoadScene("Sloth01");
    }
    //SETTINGS
    public void settings()
    {
        SceneManager.LoadScene("settings");
    }
    //QUIT
    public void quit()
    {
        Application.Quit();
    }

}
