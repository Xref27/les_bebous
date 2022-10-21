using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            Debug.Log("oui");
            GameManager.Instance.Win.SetActive(true);
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;
            Time.timeScale = 0;
        }
    }
}
