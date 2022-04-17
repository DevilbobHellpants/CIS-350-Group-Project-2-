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
    private PlayerStats enemyStats;

    public GameObject fightMenu;
    public ParticleSystem smokeEffect;

    public Image enemyPortrait;
    public Text enemyNameDisplayed;
    public Enemy[] enemies;
    public Enemy finalBoss;
    public Enemy enemyEncountered;
    public GameObject enemyHealthBar;

    public Text description;

    public GameObject[] attackButtons;
    public string[] attackNames;

    public AudioSource playerAudio;
    public AudioClip encounterSound;

    public float menuDelayTime = 2f;
    private float timer;
    private PlayerMovement player;
    public GameObject TutorialText;
    public Image darknessEffect;
    public bool startingBattle = false;

    public int encounterNum = 0;

    void Start()
    {
        enemyStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
        worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        TutorialText = GameObject.FindGameObjectWithTag("Tutorial Text");
        darknessEffect = GameObject.FindGameObjectWithTag("Darkness Effect").GetComponent<Image>();
        //description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Cloud") || other.CompareTag("Tutorial Cloud")) && !startingBattle)
        {
            Debug.Log("cloud hit");
            StartCoroutine(OpenMenuOnDelay(other.gameObject));
        }
        else if (other.CompareTag("Final Boss Cloud") && !startingBattle)
        {
            Debug.Log("Boss Fight Start");
            StartCoroutine(StartBossFight(other.gameObject));
        }
    }

    IEnumerator OpenMenuOnDelay(GameObject cloud)
    {
        StartCoroutine(playSmoke());
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
        if (darknessAlpha == 0)
        {
            darknessAlpha = .01f;
        }
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

        //setting up the menu for the specific enemy
        if (encounterNum == 0)
        {
            description.text = "A problem appears! You can see the problem's name and information on the left side of the screen.\nPress[space] to continue.";
        }
        if (encounterNum >= 1)
        {
            description.text = "A problem appears...";
        }
        int enemyNum = Random.Range(0, enemies.Length);
        enemyEncountered = enemies[enemyNum];
        enemyPortrait.sprite = enemies[enemyNum].enemySprite;
        enemyNameDisplayed.text = enemies[enemyNum].enemyName;
        enemyStats.attributes[2].value.BaseValue = enemies[enemyNum].health;
        enemyHealthBar.GetComponent<ProgressBar>().maximum = enemies[enemyNum].health;

        for (int i = 0; i < attackButtons.Length; i++)
        {
            Debug.Log(attackButtons[i].GetComponentInChildren<Text>().text);
            if (enemyNameDisplayed.text == "Glass Eye")
            {
                attackButtons[i].GetComponentInChildren<Text>().text = attackNames[i];
            }
            if (enemyNameDisplayed.text == "Liar Smiler")
            {
                attackButtons[i].GetComponentInChildren<Text>().text = attackNames[4 + i];
            }
            if (enemyNameDisplayed.text == "Scramble Sound")
            {
                attackButtons[i].GetComponentInChildren<Text>().text = attackNames[8 + i];
            }
            if (enemyNameDisplayed.text == "Question Air")
            {
                attackButtons[i].GetComponentInChildren<Text>().text = attackNames[12 + i];
            }
        }
    }

    IEnumerator StartBossFight(GameObject boss)
    {
        StartCoroutine(playSmoke());
        player.canMove = false;
        startingBattle = true;
        yield return new WaitForSeconds(menuDelayTime);

        //When the time has been waited
        boss.SetActive(false);
        startingBattle = false;
        TutorialText.SetActive(false);
        fightMenu.SetActive(true);

        //setting up the menu for the specific enemy
        description.text = "You feel a chill run up your spine...";
        enemyEncountered = finalBoss;
        enemyPortrait.sprite = finalBoss.enemySprite;
        enemyNameDisplayed.text = finalBoss.enemyName;
        enemyStats.attributes[2].value.BaseValue = finalBoss.health;
        enemyHealthBar.GetComponent<ProgressBar>().maximum = finalBoss.health;
    }

    //enemyPortrait.sprite = enemies[1].enemySprite; 

    //Plays enemy entry anim and stops time
    IEnumerator playSmoke()
    {
        //yield return new WaitForSeconds(0.5f);

        //if (smokeEffect != null) This doesn't work because smoke gets destroyed after one use, it shoulde be a prefab also smoke doesn't work anymore anyways
        //{
            playerAudio.PlayOneShot(encounterSound, .75f);
            
            //smokeEffect.Play();
            yield return new WaitForSeconds(2f);
            //Time.timeScale = 0f; Do we need to do this, this would mess up the code for the sprites when we animate them
            
            
        //}

    }
}
