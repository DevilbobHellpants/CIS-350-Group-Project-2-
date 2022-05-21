using DigitalRuby.SimpleLUT;
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
    //public ParticleSystem smokeEffect;

    public Image enemyPortrait;
    public Text enemyNameDisplayed;
    public Enemy[] enemies;
    public Enemy finalBoss;
    public Enemy enemyEncountered;
    public GameObject enemyHealthBar;
    public GameObject playerAnxietyBar;
    public GameObject bossAnim;

    public Text description;

    public GameObject[] attackButtons;
    public string[] attackNames;

    public AudioSource playerAudio;
    public AudioSource fightMusic;
    public AudioSource bossMusic;
    public AudioSource calmEndMusic;
    public AudioSource lossMusic;
    public AudioSource effectSource;

    public AudioClip winBattleSound;
    public AudioClip wrongChoice;
    public AudioClip encounterSound;
    public AudioClip positiveAction;
    public AudioClip negativeAction;

    public float menuDelayTime = 2f;
    private float timer;
    private PlayerMovement player;
    //public Image darknessEffect;
    public bool startingBattle = false;

    public int encounterNum = 0;
    public int enemyChoice = 0;

    public SimpleLUT cameraLUT;
    private UseableAttackHandler useableAttacks;
    private EnemiesTurn enemyTurn;
    public Animator enemyAnimation;

    void Start()
    {
        fightMusic.Stop();
        bossMusic.Stop();
        calmEndMusic.Stop();
        lossMusic.Stop();
        effectSource.Stop();

        enemyStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
        worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        useableAttacks = attackButtons[0].GetComponent<UseableAttackHandler>();
        enemyTurn = attackButtons[0].GetComponent<EnemiesTurn>();
        //darknessEffect = GameObject.FindGameObjectWithTag("Darkness Effect").GetComponent<Image>();
        //description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud") && !startingBattle && !player.isHidden)
        {
            Debug.Log("Normal Fight Start");
            StartCoroutine(OpenMenuOnDelay(other.gameObject));
        }
        else if (other.CompareTag("Tutorial Cloud") && !startingBattle)
        {
            Debug.Log("Tutorial Fight Start");
            StartCoroutine(OpenMenuOnDelay(other.gameObject));
        }
        else if (other.CompareTag("Lightbulb") && !startingBattle)
        {
            Debug.Log("Lightbulb Fight Start");
            StartCoroutine(StartLightbulbFight(other.gameObject));
        }
        else if (other.CompareTag("Final Boss Cloud") && !startingBattle)
        {
            Debug.Log("Boss Fight Start");
            StartCoroutine(StartBossFight(other.gameObject));
        }
    }

    IEnumerator OpenMenuOnDelay(GameObject cloud)
    {
        setUpFight();
        if (cloud.GetComponent<CloudMovement>().smoke != null)
        {
            cloud.GetComponent<CloudMovement>().smoke.gameObject.SetActive(true);
        }
        worldEffect.isStart = false;
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
        //float darknessAlpha = darknessEffect.color.a;
        float darknessAlpha = -cameraLUT.Brightness;
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
            cameraLUT.Brightness = -darknessAlpha * (menuDelayTime - timer) / menuDelayTime;
            //darknessEffect.color = new Color(0f, 0f, 0f, darknessAlpha * (menuDelayTime - timer) / menuDelayTime);
        }

        //When the time has been waited
        if (cloud.CompareTag("Tutorial Cloud"))
        {
            cloud.SetActive(false);
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
        fightMenu.SetActive(true);
        player.stopEffects(false);
        playerAnxietyBar.SetActive(true);
        enemyHealthBar.SetActive(true);

        int enemyNum = Random.Range(0, 2);
        if (enemyChoice > enemies.Length)
        {
            enemyNum = Random.Range(0, enemies.Length);
        }
        else if (enemyNum == 0)//50%
        {
            enemyNum = Random.Range(0, enemyChoice);
        }
        else//50%
        {
            enemyNum = enemyChoice - 1;
        }
        StartCoroutine(ChoseEnemy(enemyNum));
    }

    private void setUpFight()
    {
        playerAudio.Stop();
        effectSource.PlayOneShot(encounterSound, .75f);
        enemyPortrait.color = Color.white;
        player.canMove = false;
        worldEffect.inBattle = true;
        startingBattle = true;
        if (!fightMusic.isPlaying)
        {
            fightMusic.PlayDelayed(2.5f);
        }
    }

    IEnumerator ChoseEnemy(int enemyNum)
    {
        enemyAnimation.SetBool("isGlassEye", false);
        enemyAnimation.SetBool("isQuestionAir", false);
        enemyAnimation.SetBool("isScrambleSound", false);
        enemyAnimation.SetBool("isLiarSmiler", false);
        enemyAnimation.SetBool("isBoss", false);

        enemyEncountered = enemies[enemyNum];
        enemyPortrait.sprite = enemies[enemyNum].enemySprite;
        enemyNameDisplayed.text = enemies[enemyNum].enemyName;
        enemyStats.attributes[2].value.BaseValue = enemies[enemyNum].health;
        enemyHealthBar.GetComponent<ProgressBar>().maximum = enemies[enemyNum].health;

        for (int i = 0; i < attackButtons.Length; i++)
        {
            attackButtons[i].GetComponent<Button>().enabled = true;
            attackButtons[i].GetComponentInChildren<Text>().enabled = true;
            if (enemyNameDisplayed.text == "Glass Eye")
            {
                enemyAnimation.SetBool("isGlassEye", true);
                if (encounterNum == 0)
                {
                    description.text = "A problem appears! You can see the problem's name and information on the left side of the screen.\n<Press SPACE To Continue>";
                }
                else
                {
                    int descriptionTextNum = Random.Range(0, 5);
                    if (descriptionTextNum == 0)
                    {
                        description.text = "Looking at the enemy makes you want to take off your glasses.";
                    }
                    else if (descriptionTextNum == 1)
                    {
                        description.text = "The enemy looks at you behind its many ugly glasses.";
                    }
                    else if (descriptionTextNum == 2)
                    {
                        description.text = "Do I look like that when I wear my glasses?";
                    }
                    else if (descriptionTextNum == 3)
                    {
                        description.text = "You remember being called \"Glass Eyes.\"";
                    }
                    else
                    {
                        description.text = "You prepare to fight, but your glasses bother you.";
                    }
                }

                if (enemyStats.Lightbulb01pickedup == false && i == 0)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else if (enemyStats.Lightbulb02pickedup == false && i == 1)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = attackNames[i];
                }
            }
            else if (enemyNameDisplayed.text == "Liar Smiler")
            {
                enemyAnimation.SetBool("isLiarSmiler", true);
                int descriptionTextNum = Random.Range(0, 5);
                if (descriptionTextNum == 0)
                {
                    description.text = "Looking at the enemy makes you realize your alone.";
                }
                else if (descriptionTextNum == 1)
                {
                    description.text = "The enemy looks at you behind its mask laughing.";
                }
                else if (descriptionTextNum == 2)
                {
                    description.text = "Do my friends hide behind a mask when they are with me?";
                }
                else if (descriptionTextNum == 3)
                {
                    description.text = "You remember when your friends made fun of you when they thought you weren't there.";
                }
                else
                {
                    description.text = "You prepare to fight, but you feel like your friends are watching you and want to see you fail.";
                }

                if (enemyStats.Lightbulb07pickedup == false && i == 0)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else if (enemyStats.Lightbulb08pickedup == false && i == 1)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = attackNames[4 + i];
                }
            }
            else if (enemyNameDisplayed.text == "Scramble Sound")
            {
                enemyAnimation.SetBool("isScrambleSound", true);
                int descriptionTextNum = Random.Range(0, 5);
                if (descriptionTextNum == 0)
                {
                    description.text = "Looking at the enemy makes you notice the annoying sounds it makes.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else if (descriptionTextNum == 1)
                {
                    description.text = "The enemy looks at you while constantly moving back and forth at a rythmic pace.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else if (descriptionTextNum == 2)
                {
                    description.text = "If I beat him, will the annoying sounds stop?\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else if (descriptionTextNum == 3)
                {
                    description.text = "You remember how it is impossible to find peace and quiet at home.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else
                {
                    description.text = "You prepare to fight, but an annoying sound makes it hard to concentrate.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }

                if (enemyStats.Lightbulb05pickedup == false && i == 0)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else if (enemyStats.Lightbulb06pickedup == false && i == 1)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = attackNames[8 + i];
                }
            }
            else /*if (enemyNameDisplayed.text == "Question Air")*/
            {
                enemyAnimation.SetBool("isQuestionAir", true);
                int descriptionTextNum = Random.Range(0, 5);
                if (descriptionTextNum == 0)
                {
                    description.text = "Looking at the enemy fills you with questions that you don't want answered.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else if (descriptionTextNum == 1)
                {
                    description.text = "The enemy stares at you, and you are frozen unable to do anything.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else if (descriptionTextNum == 2)
                {
                    description.text = "Is it trying to ask a question?\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else if (descriptionTextNum == 3)
                {
                    description.text = "You remember the thousands of times you had a question, but were too afraid to raise your hand.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }
                else
                {
                    description.text = "You prepare to fight, but unanswered questions swarm your mind.\nThe enemy attacks first...\n<Press SPACE To Continue>";
                }

                if (enemyStats.Lightbulb03pickedup == false && i == 0)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else if (enemyStats.Lightbulb04pickedup == false && i == 1)
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    attackButtons[i].GetComponentInChildren<Text>().text = attackNames[12 + i];
                }
            }
        }

        if (enemyEncountered.attackFirst)
        {
            for (int i = 0; i < attackButtons.Length; i++)
            {
                attackButtons[i].GetComponent<Button>().enabled = false;
                attackButtons[i].GetComponentInChildren<Text>().enabled = false;
            }
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            enemyTurn.ChangeVisable(false);
            enemyTurn.enemyTurn(true);
        }
        else
        {
            enemyTurn.ChangeVisable(true);
            useableAttacks.CallSetUsableAttacks();
        }
    }

    IEnumerator StartLightbulbFight(GameObject lightbulb)
    {
        setUpFight();
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
        //float darknessAlpha = darknessEffect.color.a;
        float darknessAlpha = -cameraLUT.Brightness;
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
                clouds[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (menuDelayTime - timer) / menuDelayTime);
            }
            for (int i = 0; i < effects.Length; i++)
            {
                effects[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha[i] * (menuDelayTime - timer) / menuDelayTime);
            }
            cameraLUT.Brightness = -darknessAlpha * (menuDelayTime - timer) / menuDelayTime;
            //darknessEffect.color = new Color(0f, 0f, 0f, darknessAlpha * (menuDelayTime - timer) / menuDelayTime);
        }

        //When the time has been waited
        lightbulb.SetActive(false);
        for (int i = 0; i < clouds.Length; i++)
        {
            Destroy(clouds[i]);
        }
        for (int i = 0; i < effects.Length; i++)
        {
            Destroy(effects[i]);
        }
        startingBattle = false;
        fightMenu.SetActive(true);
        player.stopEffects(false);
        playerAnxietyBar.SetActive(true);
        enemyHealthBar.SetActive(true);

        //setting up the menu for the specific enemy
        int enemyNum = (enemyChoice % enemies.Length) - 1;
        if (enemyNum == -1)
        {
            enemyNum = enemies.Length - 1;
        }
        StartCoroutine(ChoseEnemy(enemyNum));
    }

    IEnumerator StartBossFight(GameObject boss)
    {
        playerAudio.Stop();
        effectSource.PlayOneShot(encounterSound, .75f);
        if (!bossMusic.isPlaying)
        {
            bossMusic.PlayDelayed(2.5f);
        }

        player.canMove = false;
        worldEffect.inBattle = true;
        startingBattle = true;
        yield return new WaitForSeconds(menuDelayTime);

        //When the time has been waited
        boss.SetActive(false);
        startingBattle = false;
        fightMenu.SetActive(true);
        player.stopEffects(false);
        playerAnxietyBar.SetActive(true);
        enemyHealthBar.SetActive(true);
        enemyTurn.ChangeVisable(true);

        //setting up the menu for the specific enemy
        description.text = "You feel a chill run up your spine...";
        enemyEncountered = finalBoss;
        enemyPortrait.sprite = null;
        enemyPortrait.color = Color.grey;
        enemyAnimation.SetBool("isGlassEye", false);
        enemyAnimation.SetBool("isQuestionAir", false);
        enemyAnimation.SetBool("isScrambleSound", false);
        enemyAnimation.SetBool("isLiarSmiler", false);
        enemyAnimation.SetBool("isBoss", false);
        enemyAnimation.SetBool("isBoss", true);
        //bossAnim.SetActive(true);
        enemyNameDisplayed.text = finalBoss.enemyName;
        enemyStats.attributes[2].value.BaseValue = finalBoss.health;
        enemyHealthBar.GetComponent<ProgressBar>().maximum = finalBoss.health;

        for (int i = 0; i < attackButtons.Length; i++)
        {
            attackButtons[i].GetComponent<Button>().enabled = true;
            attackButtons[i].GetComponentInChildren<Text>().enabled = true;
            if (enemyStats.Lightbulb01pickedup == false && i == 0)
            {
                attackButtons[i].GetComponentInChildren<Text>().text = "";
            }
            else if (enemyStats.Lightbulb02pickedup == false && i == 1)
            {
                attackButtons[i].GetComponentInChildren<Text>().text = "";
            }
            else
            {
                attackButtons[i].GetComponentInChildren<Text>().text = attackNames[i];
            }
        }
        useableAttacks.CallSetUsableAttacks();
    }

    //enemyPortrait.sprite = enemies[1].enemySprite;
}
