using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        gameObject.SetActive(false);
    }

}
