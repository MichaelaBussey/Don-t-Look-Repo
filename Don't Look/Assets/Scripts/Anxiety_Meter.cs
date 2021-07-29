using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anxiety_Meter : MonoBehaviour
{
    public float anxietyCurrent = 10; //This is the number which will be changed.
    public float anxietyFillAmount; //Used to hold the percentage.
    public float anxietyMaxAmount = 20; //This is the max number possible.
    public Image anxietyBar;



    public float enemyinfluence;
    public float environmentinfluence;

    void Start()
    {
        enemyinfluence = 0;
        environmentinfluence = 1;

        InvokeRepeating("AnxietyController", 0f, 1.0f); //AnxietyController is the method where the code increases anxiety. Will call this method once per second
        
    }

    public void FixedUpdate()
    {
        
        AnxietyChange();
    }

    
   

    public void AnxietyChange()
    {
        anxietyFillAmount = anxietyCurrent / anxietyMaxAmount; //Gets percentage;
        anxietyBar.fillAmount = anxietyFillAmount / 1; //Alters Image;
    }

    



    public void AnxietyController()
    {
        anxietyCurrent += enemyinfluence + environmentinfluence;

        
        
    }


}
