/*
 * Jacob Zydorowicz, Ian Connors
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
    public Animator Anim;
  

    // Update is called once per frame
    void Update()
    {
        xSpeed = Input.GetAxis("Horizontal");
        ySpeed = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * walkSpeed * xSpeed);


        transform.Translate(Vector2.up * Time.deltaTime * walkSpeed * ySpeed);


        /*WalkDir:
         * 0: None
         * 1: Up
         * 2: Down
         * 3: Right
         * 4: Left
         */
        if (xSpeed == 0 && ySpeed == 0)
		{
            Anim.SetInteger("WalkDir", 0);
		}
        else if (xSpeed > 0.5f)
		{
            Anim.SetInteger("WalkDir", 3);
        }
        else if (xSpeed < -0.5f)
        {
            Anim.SetInteger("WalkDir", 4);
        }
        else if (ySpeed > 0)
        {
            Anim.SetInteger("WalkDir", 1);
        }
        else if (ySpeed < 0)
        {
            Anim.SetInteger("WalkDir", 2);
        }
    }
}

