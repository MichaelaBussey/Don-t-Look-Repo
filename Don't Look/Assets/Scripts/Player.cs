using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //this is one of the movement scripts recommended by Brackeys
    //it uses the axes for detecting input
    // also makes use of a rigidbody2d with gravity scale set to 0

    [Header("References")]
    Vector2 movement;

    Rigidbody2D rb;
    public float movespeed;
    public float percentMod; //between 0 and 1
    public Animator player_animator;
    public GameObject Text1, Text2, PauseUI;

    public bool diagTest;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical") * percentMod;

        //decreases diagonal movement if there is no 0 on one of the axes.
        
        {

            if (movement.x != 0 && movement.y != 0)
            {  //therefore there is movement on both axes


                movement.x = movement.x * 0.6f;
                movement.y = movement.y * 0.6f;

            }
        }

        player_animator.SetFloat("Horizontal", movement.x);
        player_animator.SetFloat("Vert", movement.y);

        player_animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) 
    {

            if (col.gameObject.tag == "TEXT2COL")
            {
                print("Walk");
                Destroy(Text1);
                Text2.SetActive(true);
            Destroy(col);
            
            }

            if (col.gameObject.tag == "PAUSECOL")
            {
                Destroy(Text2);
                PauseUI.SetActive(true);
            Destroy(col);
        }

    }
}
