using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anxiety_Meter : MonoBehaviour
{
   
    public void AnxietyChange()
    {
        anxietyFillAmount = anxietyCurrent / anxietyMaxAmount; //Gets percentage;
        anxietyBar.fillAmount = anxietyFillAmount / 1; //Alters Image;
    }

    private float anxietyCurrent = 10; //This is the number which will be changed.
    private float anxietyFillAmount; //Used to hold the percentage.
    private float anxietyMaxAmount = 20; //This is the max number possible.
    public Image anxietyBar;


    //if (inContactWithEnemy == true)
    //{
    //anxietyCurrent += 1;
    //}

    //in fixedUpdate

    //{
    //  anxietyCurrent += 1 once per second;
    //}

    //if (light contact == true)
    //{
    //  anxietyCurrent -= 3;
    //}
    //}
}
