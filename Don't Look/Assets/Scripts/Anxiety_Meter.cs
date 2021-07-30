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

    public GameObject Winscreen;
    public GameObject Losescreen;

    public float enemyinfluence;
    public float environmentinfluence;

    public float shadowCD;
    public float maxCD;

    public AudioSource PlayerFootstep;


    void Start()
    {
        Time.timeScale = 1f;
        enemyinfluence = 0;
        environmentinfluence = 1;

        InvokeRepeating("AnxietyController", 0f, 0.25f); //AnxietyController is the method where the code increases anxiety. Will call this method once per second
        
    }

    public void Footstep()
    {
        PlayerFootstep.Play();
    }

    public void Update()
    {
        if (this.gameObject.GetComponent<DetectionCircle>().underLight == false)
        {
            //player is in the darkness
            shadowCD += 0.01f;


            if (shadowCD >= 0.5 * maxCD && shadowCD < maxCD)
            {
                environmentinfluence = 2;
            }
            else if (shadowCD >= maxCD)
            {
                environmentinfluence = 3;
            }
            
        }
    }

    public void FixedUpdate()
    {
        if (anxietyCurrent >= anxietyMaxAmount)
        {
            Losescreen.SetActive(true);
            Time.timeScale = 0.0f;
        }

        AnxietyChange();
    }

    public void AnxietyChange()
    {
        anxietyFillAmount = anxietyCurrent / anxietyMaxAmount; //Gets percentage;
        anxietyBar.fillAmount = anxietyFillAmount / 1; //Alters Image;
    }

    public void AnxietyController()
    {
        anxietyCurrent += 0.25f * (enemyinfluence + environmentinfluence);


        if (anxietyCurrent > anxietyMaxAmount)
        { 
            anxietyCurrent = anxietyMaxAmount;
        }
        else if (anxietyCurrent < 0)
        {
            anxietyCurrent = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "light")
        {
            environmentinfluence = -3;
            this.gameObject.GetComponent<DetectionCircle>().underLight = true;
            
        }

        if (collision.gameObject.tag == "win")
        {
            Winscreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "light")
        {
            environmentinfluence = 1;
            this.gameObject.GetComponent<DetectionCircle>().underLight = false;
            shadowCD = 0;
            
        }
    }

}
