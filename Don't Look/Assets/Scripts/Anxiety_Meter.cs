using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anxiety_Meter : MonoBehaviour
{
    private float anxietyCurrent = 10; //This is the number which will be changed.
    private float anxietyFillAmount; //Used to hold the percentage.
    private float anxietyMaxAmount = 20; //This is the max number possible.
    public Image anxietyBar;

    void Start()
    {
        InvokeRepeating("AnxietyIncrease", 0f, 1.0f); //AnxietyIncrease is the method where the code increases anxiety. Will call this method once per second
        
    }

    public void FixedUpdate()
    {
        if (IsEnemy == true)
        {
            InvokeRepeating("EnemyAnxietyIncrease", 0f, 1.0f);
        }
    }

    public void AnxietyChange()
    {
        anxietyFillAmount = anxietyCurrent / anxietyMaxAmount; //Gets percentage;
        anxietyBar.fillAmount = anxietyFillAmount / 1; //Alters Image;
    }

    public void AnxietyIncrease()
    {
        anxietyCurrent += 1;
    }

    public void EnemyAnxietyIncrease()
    {
        anxietyCurrent += 1;
    }


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
