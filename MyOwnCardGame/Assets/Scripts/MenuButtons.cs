using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//placed on MenuHandler
public class MenuButtons : MonoBehaviour
{
    public void LoadScene(string NameOfTheScene)
    {
        SceneManager.LoadScene(NameOfTheScene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Website()
    {
        Application.OpenURL("https://github.com/jeti20?tab=repositories");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
