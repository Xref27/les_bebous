using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Pause;
    public bool IsPause;

    public void quit()
    {
        Application.Quit();
        Debug.Log("le jeu est quitté bg fais moi confiance");
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void SetPause(bool value)
    {
        Pause.SetActive(value);
        IsPause = value;

        if (value)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        Debug.Log(Time.timeScale);
    }
}