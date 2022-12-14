using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//placed on MenuHandler
public class MenuButtons : MonoBehaviour
{
    public AudioSource UI;
    public AudioSource Level;

    public void LoadScene(string NameOfTheScene)
    {
        StartCoroutine(SoundPlay());
        SceneManager.LoadScene(NameOfTheScene);
        
    }

    IEnumerator SoundPlay()
    {
        Level.Play();
        yield return new WaitForSeconds(5f);
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

    public void UISound()
    {
        UI.Play();
    }
}
