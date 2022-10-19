using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void quit()
        {
            Application.Quit();
        }

        public void MyLoadScene(int idScene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(idScene);
            Time.timeScale = 1;
        }
    }
}
