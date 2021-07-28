﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    //script for changing/reloading scenes, and toggling objects on and off, as well as exiting the game

    public void Scenechanger(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        

        Application.Quit();


    }

    public void ToggleObjectOff(GameObject target)
    {

        //set inactive
        target.SetActive(false);

    }

    public void ToggleObjectOn(GameObject target)
    {
        //set active
        target.SetActive(true);
    }


    
    

}
