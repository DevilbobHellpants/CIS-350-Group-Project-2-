using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker, Jacob Zydorowicz, Caleb Kahn
 * Project 5 
 * Opens the fight menu when player touches a cloud.
 */

//this is supposed to be attached to the cloud prefab- might recode it to be attached to the player because this "FindGameObjectWithTag" isn't finding the game object with tag.
public class OpenFightMenu : MonoBehaviour
{
    private OverworldAnxietyEffect worldEffect;

    public GameObject fightMenu;
    public ParticleSystem smokeEffect;
    public Sprite enemyPortrait;
    public Enemy[] enemies;

    public AudioSource playerAudio;
    public AudioClip encounterSound;

    public float menuDelayTime = 2f;
    private float timer;
    private PlayerMovement player;
    public GameObject TutorialText;
    public Image darknessEffect;
    private bool startingBattle = false;

    void Start()
    {
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
        worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        TutorialText = GameObject.FindGameObjectWithTag("Tutorial Text");
        darknessEffect = GameObject.FindGameObjectWithTag("Darkness Effect").GetComponent<Image>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Cloud") || other.CompareTag("Tutorial Cloud")) && !startingBattle)
        {
            Debug.Log("cloud hit");
            StartCoroutine(OpenMenuOnDelay(other.gameObject));
        }
    }

    IEnumerator OpenMenuOnDelay(GameObject cloud)
    {
        if (!smokeEffect.isPlaying)
        {
            playerAudio.PlayOneShot(encounterSound, .75f);
            StartCoroutine(playSmoke());
        }
        player.canMove = false;
        worldEffect.inBattle = true;
        startingBattle = true;
        cloud.GetComponent<CloudMovement>().inBattle = true;
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        GameObject[] effects = GameObject.FindGameObjectsWithTag("PhysicalAnxietyEffect");
        float[] alpha = new float[effects.Length];
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].GetComponent<OverworldEffectMovement>().inBattle = true;
            alpha[i] = effects[i].GetComponent<SpriteRenderer>().color.a;
        }
        for (int i = 0; i < clouds.Length; i++)
        {
            clouds[i].GetComponent<CloudMovement>().canDie = false;
        }
        float darknessAlpha = darknessEffect.color.a;
        timer = 0;
        while (timer < menuDelayTime)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            for (int i = 0; i < clouds.Length; i++)
            {
                if (clouds[i] != cloud)
                {
                    clouds[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (menuDelayTime - timer) / menuDelayTime);
                }
            }
            for (int i = 0; i < effects.Length; i++)
            {
                effects[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha[i] * (menuDelayTime - timer) / menuDelayTime);
            }
            darknessEffect.color = new Color(0f, 0f, 0f, darknessAlpha * (menuDelayTime - timer) / menuDelayTime);
        }

        //When the time has been waited
        if (cloud.CompareTag("Tutorial Cloud"))
        {
            Destroy(cloud);
        }
        for (int i = 0; i < clouds.Length; i++)
        {
            Destroy(clouds[i]);
        }
        for (int i = 0; i < effects.Length; i++)
        {
            Destroy(effects[i]);
        }
        startingBattle = false;
        TutorialText.SetActive(false);
        fightMenu.SetActive(true);
    }

    //enemyPortrait.sprite = enemies[1].enemySprite; 
    // was testing something,,, going to wait until i understand the combat system before i mess with the enemies.

    //Plays enemy entry anim and stops time
    IEnumerator playSmoke()
    {
        //yield return new WaitForSeconds(0.5f);

        if (smokeEffect != null)
        {
            playerAudio.PlayOneShot(encounterSound, .75f);
            
            smokeEffect.Play();
            yield return new WaitForSeconds(2);
            Time.timeScale = 0f;
            
            
        }

    }
}
