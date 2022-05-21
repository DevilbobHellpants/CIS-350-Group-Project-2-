/*
 * Jacob Zydorowicz, Ian Connors, Caleb Kahn
 * Project 5
 * Controls player movement and actions in overworld
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Image blindImage;
    public Image hiddenImage;
    public Image slowImage;
    public Image loudImage;
    public Image increasedSpawnImage;
    public Image decreasedSpawnImage;
    public Image drunkImage;
    public Image emptyImage;

    public float maxDistence = .3f;
    private Vector2 previousLocation;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Camera camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public bool inBattle = false;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Rigidbody2D rigidbody;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        canMove = false;
        StartCoroutine(WaitOnStart());
        //StartCoroutine(UpdatePosition());
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
    /*
    IEnumerator UpdatePosition()
    {
        while(true)
        {
            previousLocation = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }*/

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
        if (!isBlind && !isHidden && !isSlow && !isIncreasedSpawnRate && !isLoud && !isDecreasedSpawnRate && !isDrunk)
        {
            emptyImage.gameObject.SetActive(true);
        }
        else
        {
            emptyImage.gameObject.SetActive(false);
        }
        if (isBlind)
        {
            camera.GetComponent<PostProcessVolume>().enabled = true;
            blindImage.gameObject.SetActive(true);
        }
        if (isHidden)
        {
            Anim.SetBool("Glitch", true);
            hiddenImage.gameObject.SetActive(true);
        }
        if (isSlow)
        {
            walkSpeed *= .65f;
            slowImage.gameObject.SetActive(true);
        }
        if (isIncreasedSpawnRate && isLoud)
        {
            increasedSpawnImage.rectTransform.anchoredPosition = new Vector3(10f, -95f, 0);
            loudImage.rectTransform.anchoredPosition = new Vector3(90f, -95f, 0);
            increasedSpawnImage.gameObject.SetActive(true);
            loudImage.gameObject.SetActive(true);
        }
        else if (isIncreasedSpawnRate)
        {
            increasedSpawnImage.rectTransform.anchoredPosition = new Vector3(50f, -95f, 0);
            increasedSpawnImage.gameObject.SetActive(true);
        }
        else if (isLoud)
        {
            loudImage.rectTransform.anchoredPosition = new Vector3(50f, -95f, 0);
            loudImage.gameObject.SetActive(true);
        }
        if (isDecreasedSpawnRate && isDrunk)
        {
            decreasedSpawnImage.rectTransform.anchoredPosition = new Vector3(10f, -95f, 0);
            drunkImage.rectTransform.anchoredPosition = new Vector3(90f, -95f, 0);
            decreasedSpawnImage.gameObject.SetActive(true);
            StartCoroutine(DrunkenMovment());
            drunkImage.gameObject.SetActive(true);
        }
        else if (isDecreasedSpawnRate)
        {
            decreasedSpawnImage.rectTransform.anchoredPosition = new Vector3(50f, -95f, 0);
            decreasedSpawnImage.gameObject.SetActive(true);
        }
        else if (isDrunk)
        {
            drunkImage.rectTransform.anchoredPosition = new Vector3(50f, -95f, 0);
            StartCoroutine(DrunkenMovment());
            drunkImage.gameObject.SetActive(true);
        }
        float timer = 0f;
        yield return new WaitForFixedUpdate();
        while (!inBattle && timer < 25)
        {
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        if (isHidden)
        {
            StartCoroutine(SlowlyFadeImage(hiddenImage));
        }
        if (isLoud)
        {
            StartCoroutine(SlowlyFadeImage(loudImage));
        }
        if (isDrunk)
        {
            StartCoroutine(SlowlyFadeImage(drunkImage));
        }
    }

    IEnumerator SlowlyFadeImage(Image image)
    {
        float timer = 0f;
        while (!inBattle && timer < 2f)
        {
            timer += Time.deltaTime;
            image.color = new Color(1f, 1f, 1f, .75f + (.25f * ((2f - timer)/2f)));
            yield return new WaitForFixedUpdate();
        }
        timer = 0f;
        while (!inBattle && timer < 1.5f)
        {
            timer += Time.deltaTime;
            image.color = new Color(1f, 1f, 1f, .5f + (.5f * ((1.5f - timer) / 1.5f)));
            yield return new WaitForFixedUpdate();
        }
        timer = 0f;
        while (!inBattle && timer < 1f)
        {
            timer += Time.deltaTime;
            image.color = new Color(1f, 1f, 1f, .25f + (.75f * (1f - timer)));
            yield return new WaitForFixedUpdate();
        }
        timer = 0f;
        while (!inBattle && timer < .5f)
        {
            timer += Time.deltaTime;
            image.color = new Color(1f, 1f, 1f, (.5f - timer) / .5f);
            yield return new WaitForFixedUpdate();
        }
        image.color = Color.white;
        image.gameObject.SetActive(false);
        if (image == hiddenImage)
        {
            isHidden = false;
            Anim.SetBool("Glitch", false);
        }
        if (image == loudImage)
        {
            isLoud = false;
            camera.GetComponent<AudioDistortionFilter>().enabled = false;
            if (isIncreasedSpawnRate)
            {
                increasedSpawnImage.rectTransform.anchoredPosition = new Vector3(50f, -95f, 0);
            }
            else
            {
                emptyImage.gameObject.SetActive(true);
            }
        }
        if (image == drunkImage)
        {
            isDrunk = false;
            if (isDecreasedSpawnRate)
            {
                decreasedSpawnImage.rectTransform.anchoredPosition = new Vector3(50f, -95f, 0);
            }
            else
            {
                emptyImage.gameObject.SetActive(true);
            }
        }
    }

    public void stopEffects(bool died)
    {
        emptyImage.gameObject.SetActive(true);
        if (!died)
        {
            inBattle = true;
        }
        if (isBlind)
        {
            isBlind = false;
            camera.GetComponent<PostProcessVolume>().enabled = false;
            blindImage.gameObject.SetActive(false);
        }
        if (isHidden)
        {
            isHidden = false;
            Anim.SetBool("Glitch", false);
            hiddenImage.gameObject.SetActive(false);
        }
        if (isSlow)
        {
            if (!died)
            {
                walkSpeed /= .65f;
            }
            isSlow = false;
            slowImage.gameObject.SetActive(false);
        }
        if (isLoud)
        {
            isLoud = false;
            camera.GetComponent<AudioDistortionFilter>().enabled = false;
            loudImage.gameObject.SetActive(false);
        }
        if (isIncreasedSpawnRate)
        {
            isIncreasedSpawnRate = false;
            increasedSpawnImage.gameObject.SetActive(false);
        }
        if (isDecreasedSpawnRate)
        {
            isDecreasedSpawnRate = false;
            decreasedSpawnImage.gameObject.SetActive(false);
        }
        if (isDrunk)
        {
            isDrunk = false;
            drunkImage.gameObject.SetActive(false);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            xSpeed = Input.GetAxis("Horizontal");
            ySpeed = Input.GetAxis("Vertical");
            rigidbody.velocity = new Vector2(xSpeed, ySpeed).normalized * walkSpeed;
            /*Vector2 addedPosition = new Vector2(xSpeed, ySpeed).normalized * walkSpeed;
            if (Mathf.Abs(previousLocation.x - (transform.position.x + addedPosition.x)) < maxDistence && Mathf.Abs(previousLocation.y - (transform.position.y + addedPosition.y)) < maxDistence)
            {
                transform.Translate(addedPosition);
            }*/


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
        else
        {
            rigidbody.velocity = Vector2.zero;
        }
    }

    /*public void resetStats()
    {
        isBlind = false;
        isHidden = false;
        isSlow = false;
        isIncreasedSpawnRate = false;
        isDecreasedSpawnRate = false;
        isDrunk = false;
    }*/
}