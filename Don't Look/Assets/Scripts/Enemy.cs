using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //basic script for the enemy behaviours
    //this script should contain code for the patrol behaviour of the enemies
    //customers should have 4 nodes at the space of their feet
    //and at each corner of their box collider 
    //needs a capsule collider (or not?) and a rigidbody2d with gravity turned off
    //set raymask to level mask

    public enum AIState { PATROL, IDLE, STALK }
    public enum EnemyType { LURKER, STALKER, REACTOR }

    [Header("References")]
    public AIState state;
    public Transform one, two, three, four; //the four nodes at their feet. In order: bottom left, bottom right, top right, top left.
    public LayerMask raymask;

    public Vector3 playerposition;

    [Header("Set Variables")] //variables that need to be toggled in inspector
    public float walkspeed;
    public float modifier; //because i set the scale too damn small haha
    public EnemyType type; //lurkers just chill, stalkers will chase, and reactors will have other special effects like wolfwhistles or heckling or will throw comments.

    [Header("Additional Info Variables")]
    public int movedistance;
    public float speed;
    public int rayhit;
    public Vector3 direction;
    public Vector3 endpoint;
    public RaycastHit2D hit, hit2;
    public Vector3 target; //the transform details of the target position/player, which the enemy may or may not approach (depending on the type of enemy)


    public void Start()
    {
        state = AIState.IDLE;
        Scan();
    }

    public void Update()
    {
        //controls when the enemy should be moving or not moving
        if (state == AIState.PATROL || state == AIState.STALK)
        {
            speed = walkspeed;
        }
        else if (state == AIState.IDLE)
        {
            speed = 0;
        }


        //move enemy towards desired location
        if (state == AIState.PATROL)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else if (state == AIState.STALK)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, playerposition, speed * Time.deltaTime);
        }


        //checks whether the enemy has reached their desired location or not
        if (state == AIState.PATROL && transform.position == target)
        {


            state = AIState.IDLE;
            StartCoroutine(Idle());


        }
        else if (state == AIState.STALK && transform.position == playerposition)
        {
            state = AIState.IDLE;
            StartCoroutine(Idle());
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                Anxiety_Meter anxiety_Meter = GameObject.FindWithTag("Player").GetComponent<Anxiety_Meter>();
                anxiety_Meter.anxietyCurrent = 18;
        }
    }

    public void Scan()
    {
        //the general gist is that the enemy will pick a random direction (up, down, left, right) and cast two rays in the chosen direction, based on the nodes at their feet position.
        //if those rays hit anything, they pick another direction
        //if those rays do not collide with any level colliders, the enemy will move in that direction for a short distance


        rayhit = 0;

        //chooses a random direction for the customer to go in
        int random = Random.Range(0, 4);
        movedistance = Random.Range(2, 4);
        if (random == 0)
        {
            //look up
            direction = Vector3.up;
            endpoint = new Vector3(this.transform.position.x, this.transform.position.y + (movedistance * modifier), this.transform.position.z);
        }
        else if (random == 1)
        {
            //look down
            direction = Vector3.down;
            endpoint = new Vector3(this.transform.position.x, this.transform.position.y - (movedistance * modifier), this.transform.position.z);
        }
        else if (random == 2)
        {
            //look left
            direction = Vector3.left;
            endpoint = new Vector3(this.transform.position.x - (movedistance * modifier), this.transform.position.y, this.transform.position.z);
        }
        else if (random == 3)
        {
            //look right
            direction = Vector3.right;
            endpoint = new Vector3(this.transform.position.x + (movedistance * modifier), this.transform.position.y, this.transform.position.z);
        }


        //casts two rays depending on which direction they choose
        if (random == 0)
        {
            //look up
            hit = Physics2D.Raycast(three.position, direction, movedistance * modifier, raymask);
            hit2 = Physics2D.Raycast(four.position, direction, movedistance * modifier, raymask);

        }
        else if (random == 1)
        {
            //look down
            hit = Physics2D.Raycast(two.position, direction, movedistance * modifier, raymask);
            hit2 = Physics2D.Raycast(one.position, direction, movedistance * modifier, raymask);

        }
        else if (random == 2)
        {
            //look left
            hit = Physics2D.Raycast(four.position, direction, movedistance, raymask);
            hit2 = Physics2D.Raycast(one.position, direction, movedistance, raymask);

        }
        else
        {
            //look right
            hit = Physics2D.Raycast(two.position, direction, movedistance, raymask);
            hit2 = Physics2D.Raycast(three.position, direction, movedistance, raymask);

        }




        if (hit.collider == null)
        {
            rayhit += 1;
        }

        if (hit2.collider == null)
        {
            rayhit += 1;
        }



        if (rayhit == 2)
        {
            //the path is clear
            //move enemy to new location
            target = endpoint;
            state = AIState.PATROL;

        }
        else
        {
            //the path is blocked by some level element, rescan
            Scan();

        }

    }


    public IEnumerator Idle()
    {
        //stalls the enemy for a random amount of time between patrolling/movement

        int idletimer;
        idletimer = Random.Range(1, 5);

        yield return new WaitForSeconds(idletimer);

        if (state != AIState.STALK)
        {
            Scan();
        }


    }


    public void StalkPlayer(Vector3 playertransform)
    {



        //casts 4 rays from the feet position of enemy to the player, to see if there are any level elements in the way

        int rayhit = 0;
        RaycastHit2D hit, hit2, hit3, hit4;

        var direction = playertransform - one.transform.position;
        hit = Physics2D.Raycast(one.position, direction, Vector2.Distance(playertransform, one.position), raymask);

        if (hit.collider == null)
        {
            rayhit += 1;
        }

        direction = playertransform - two.transform.position;
        hit2 = Physics2D.Raycast(two.position, direction, Vector2.Distance(playertransform, two.position), raymask);

        if (hit2.collider == null)
        {
            rayhit += 1;
        }


        direction = playertransform - three.transform.position;
        hit3 = Physics2D.Raycast(three.position, direction, Vector2.Distance(playertransform, three.position), raymask);

        if (hit3.collider == null)
        {
            rayhit += 1;
        }

        direction = playertransform - four.transform.position;
        hit4 = Physics2D.Raycast(four.position, direction, Vector2.Distance(playertransform, four.position), raymask);

        if (hit4.collider == null)
        {
            rayhit += 1;
        }


        if (rayhit == 4)
        {

            if (state != AIState.STALK)
            {
                state = AIState.STALK;
            }
            playerposition = playertransform;



        }



    }
}
