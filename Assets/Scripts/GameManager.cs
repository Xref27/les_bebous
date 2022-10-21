using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Win;
    public bool IsPause;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("le jeu est quitté bg fais moi confiance source : trust me");
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Niveau_1");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Eliass");
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
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsPause == true) { 
                SetPause(false);
                IsPause = false;
            } else
            {
                SetPause(true);
                IsPause = true;
            }
        }

    }
}
