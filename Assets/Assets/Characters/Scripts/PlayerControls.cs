using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //---Bound in Unity---
    [SerializeField]
    private float Speed; //controls players speed
    [SerializeField]
    private float Thrust; //controls force player has

    //---Set Dynamically---
    private Animator Anime;
    private Rigidbody2D Body;

    // Start is called before the first frame update
    void Start()
    {
        Anime = this.GetComponent<Animator>(); //Grabs Animator from player
        Body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero;
        Walk(Anime, moveDirection, Body);
    }

    void Walk(Animator anime, Vector2 moveDirection, Rigidbody2D rb)
    { //Controls characters movement
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > .3f || horizontal < -.3f) //If moving horizontally
        {
            anime.SetBool("Walking", true);
            anime.SetFloat("XDirection", horizontal);
            anime.SetFloat("YDirection", 0);
            moveDirection.x = horizontal;
        }
        else if (vertical > .3f || vertical < -.3f) //If moving vertically
        {
            anime.SetBool("Walking", true);
            anime.SetFloat("XDirection", 0);
            anime.SetFloat("YDirection", vertical);
            moveDirection.y = vertical;
        }
        else //If standing still
        {
            anime.SetBool("Walking", false);
            anime.SetFloat("XDirection", 0);
            anime.SetFloat("YDirection", 0);
        }

        //Actually moves the character
        rb.velocity = moveDirection * Speed * 2;
        Debug.Log($"Horizontal: {horizontal}\tVertical: {vertical}"); //Unity logging
    }

}
