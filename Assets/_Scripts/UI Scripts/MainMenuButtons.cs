using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene("Options");
    }
    public void OnExitButtonPressed()
    {
        Application.Quit();
    }
    public void OnBackButtonPressed()
    {
        Debug.Log("Main Menu Button");
        SceneManager.LoadScene("Main Menu");
    }
    public void OnResumeButtonPressed()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().Unpause();
    }
    public void OnMainMenuPausePressed()
    {
        Time.timeScale = 1;
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().pauseCanvas.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
}
