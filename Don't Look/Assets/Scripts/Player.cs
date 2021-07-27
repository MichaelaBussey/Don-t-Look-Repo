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

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical") * percentMod;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
    }
}
