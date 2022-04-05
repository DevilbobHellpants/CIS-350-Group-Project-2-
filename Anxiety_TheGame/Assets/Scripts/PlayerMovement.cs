/*
 * Jacob Zydorowicz
 * Project 5
 * Controls player movement and actions in overworld
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public float walkSpeed;
  

    // Update is called once per frame
    void Update()
    {
        xSpeed = Input.GetAxis("Horizontal");
        ySpeed = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * walkSpeed * xSpeed);


        transform.Translate(Vector2.up * Time.deltaTime * walkSpeed * ySpeed);


    }
}

