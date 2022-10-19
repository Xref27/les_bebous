using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
        Debug.Log("le jeu est quitté bg fais moi confiance");
    }

    public void MyLoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
