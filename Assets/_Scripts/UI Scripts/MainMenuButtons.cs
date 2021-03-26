using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().UIButtonPress);
        SceneManager.LoadScene("Level 1");
    }
    public void OnOptionsButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().UIButtonPress);
        SceneManager.LoadScene("Options");
    }
    public void OnExitButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().UIButtonPress);
        Application.Quit();
    }
    public void OnBackButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().UIButtonPress);
        Debug.Log("Main Menu Button");
        SceneManager.LoadScene("Main Menu");
    }
    public void OnResumeButtonPressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().UIButtonPress);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().Unpause();
    }
    public void OnMainMenuPausePressed()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().UIButtonPress);
        Time.timeScale = 1;
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().pauseCanvas.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
}
