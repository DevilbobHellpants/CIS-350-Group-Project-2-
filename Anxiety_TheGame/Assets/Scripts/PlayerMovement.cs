/*
 * Jacob Zydorowicz, Ian Connors, Caleb Kahn
 * Project 5
 * Controls player movement and actions in overworld
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMovement : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public float walkSpeed;
    public Animator Anim;
    public bool canMove;

    public bool isBlind;
    public bool isHidden;
    public bool isSlow;
    public bool isLoud;
    public bool isIncreasedSpawnRate;
    public bool isDecreasedSpawnRate;
    public bool isDrunk;

    public float maxDistence = .3f;
    private Vector2 previousLocation;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Camera camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    private bool inBattle = false;

    private void Start()
    {
        canMove = false;
        StartCoroutine(WaitOnStart());
        StartCoroutine(UpdatePosition());
        StartCoroutine(SpriteGlitch());
    }

    IEnumerator WaitOnStart()
    {
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }

    IEnumerator DrunkenMovment()
    {
        while(isDrunk)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!inBattle)
                {
                    yield return new WaitForSeconds(UnityEngine.Random.Range(.6f, 1.4f));// 3-7 seconds
                }
            }
            walkSpeed = walkSpeed * -1;
        }
        walkSpeed = Mathf.Abs(walkSpeed);
    }

    IEnumerator UpdatePosition()
    {
        while(true)
        {
            previousLocation = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator SpriteGlitch()
	{
        while (true)
		{
            yield return new WaitForSeconds(Random.Range(1.1f, 2.1f));
            Anim.SetBool("Glitch", true);
            yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
            if (!isHidden)
            {
                Anim.SetBool("Glitch", false);
            }
		}
    }

    public void CallStartEffects()
    {
        StartCoroutine(StartEffects());
    }

    IEnumerator StartEffects()
    {
        inBattle = false;
        if (isBlind)
        {
            camera.GetComponent<PostProcessVolume>().enabled = true;
        }
        if (isHidden)
        {
            Anim.SetBool("Glitch", true);
        }
        if (isSlow)
        {
            walkSpeed *= .6f;
        }
        if (isDrunk)
        {
            StartCoroutine(DrunkenMovment());
        }
        float timer = 0;
        yield return new WaitForFixedUpdate();
        while (!inBattle && timer < 30)
        {
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        if (isHidden)
        {
            Anim.SetBool("Glitch", false);
            isHidden = false;
        }
        if (isLoud)
        {
            camera.GetComponent<AudioDistortionFilter>().enabled = false;
        }
        if (isDrunk)
        {
            isDrunk = false;
        }
        /*isBlind;
    isSlow;
    isIncreasedSpawnRate;
    isDecreasedSpawnRate;*/
    }

    public void stopEffects(bool died)
    {
        if (!died)
        {
            inBattle = true;
        }
        if (isBlind)
        {
            isBlind = false;
            camera.GetComponent<PostProcessVolume>().enabled = false;
        }
        if (isHidden)
        {
            Anim.SetBool("Glitch", false);
            isHidden = false;
        }
        if (isSlow && !died)
        {
            walkSpeed /= .6f;
        }
        if (isLoud)
        {
            camera.GetComponent<AudioDistortionFilter>().enabled = false;
        }
        if (isIncreasedSpawnRate)
        {
            isIncreasedSpawnRate = false;
        }
        if (isDecreasedSpawnRate)
        {
            isDecreasedSpawnRate = false;
        }
        if (isDrunk)
        {
            isDrunk = false;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            xSpeed = Input.GetAxis("Horizontal");
            ySpeed = Input.GetAxis("Vertical");
            Vector2 addedPosition = new Vector2(xSpeed, ySpeed).normalized * walkSpeed * Time.deltaTime;
            if (Mathf.Abs(previousLocation.x - (transform.position.x + addedPosition.x)) < maxDistence && Mathf.Abs(previousLocation.y - (transform.position.y + addedPosition.y)) < maxDistence)
            {
                transform.Translate(addedPosition);
            }


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
            else if (xSpeed > 0)
            {
                Anim.SetInteger("WalkDir", 3);
            }
            else if (xSpeed < 0)
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

    public void resetStats()
    {
        isBlind = false;
        isHidden = false;
        isSlow = false;
        isIncreasedSpawnRate = false;
        isDecreasedSpawnRate = false;
        isDrunk = false;
    }
}