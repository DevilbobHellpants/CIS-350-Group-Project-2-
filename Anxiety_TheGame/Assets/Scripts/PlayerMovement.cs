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
    public bool canMove;

    private PlayerStats drunkStat;

    private bool inDrunkenMovment;

    private void Start()
    {
        canMove = false;
        StartCoroutine(WaitOnStart());
        drunkStat = GetComponent<PlayerStats>();
        inDrunkenMovment = false;
    }

    IEnumerator WaitOnStart()
    {
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }

    IEnumerator DrunkenMovment()
    {
        inDrunkenMovment = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 7f));
        walkSpeed = walkSpeed * -1;
        inDrunkenMovment = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (drunkStat.attributes[1].value.BaseValue >= 3 && inDrunkenMovment == false)
        {
            Debug.Log("Corutine Started");
            StartCoroutine(DrunkenMovment());
        }
        if (drunkStat.attributes[1].value.BaseValue < 3 && Mathf.Sign(walkSpeed) == -1)
        {
            walkSpeed = walkSpeed * -1;
        }
        if (canMove)
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
}

