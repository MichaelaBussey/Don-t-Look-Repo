using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextsandPause : MonoBehaviour
{
    public GameObject Text1, Text2, PausePhone, PauseUI;
    public GameObject help;

    public void Start()
    {
        if (help != null)
        { 

        help.SetActive(false);
    }
    }
    void Update()
    {
        
    }

    public void howtoplay()
    {
        help.SetActive(true);
    }
    public void PausePhoneCanvas ()
    {
        Time.timeScale = 0.05f;
        PausePhone.SetActive(false);
        PauseUI.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void Close()
    {
        Time.timeScale = 1f;
        PauseUI.SetActive(false);
        PausePhone.SetActive(true);
    }


public void Text1Canvas ()
    {
        Text1.SetActive(false);
    }

    public void Text2Canvas()
    {
        Text2.SetActive(false);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TEXT2COL")
        {
            print("Walk");
            Destroy(Text1);
            Text2.SetActive(true);
        }

        if (collision.gameObject.tag == "PAUSECOL")
        {
            Destroy(Text2);
            PauseUI.SetActive(true);
        }
    }*/

}
