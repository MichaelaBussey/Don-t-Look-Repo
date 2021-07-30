using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCircle : MonoBehaviour
{
    [Header("References")]
    public float lightmodifier; //how much the light radius changes, depending on whether the players light is on or off
    public float viewRadius;
    public float desiredRad;
    public LayerMask enemymask;
    //public List<GameObject> nearbyEnemies = new List<GameObject>();

    public bool lightOn;
    public bool underLight;

    // Start is called before the first frame update
    void Start()
    {
        lightOn = false;
        underLight = false;
    }

    public void Update()
    {
        Ping();
    }


    public void Ping()
    {


        //alters the radius of the detection circle, depending on if the players light is on or not
        if (lightOn)
        {
            desiredRad = viewRadius + lightmodifier;
        }
        else
        {
            desiredRad = viewRadius;
        }

        
        {

            //checks if there are any enemies within the detection circle - i need to collect a list/array of all colliders
            Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, desiredRad, enemymask);


            for (int i = 0; i < nearbyEnemies.Length; i++)
            {
                GameObject anEnemy = nearbyEnemies[i].gameObject;

                //if ()
                //{

                //}

                if (anEnemy.GetComponent<Enemy>().type == Enemy.EnemyType.STALKER)
                {

                    {
                        Vector3 playerpos = this.transform.position;
                        anEnemy.GetComponent<Enemy>().StalkPlayer(playerpos);
                    }
                }

            }
        }


    }
}
