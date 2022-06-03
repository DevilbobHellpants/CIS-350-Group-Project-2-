using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Anna Breuker, Caleb Kahn, Jacob Zydorowicz
 * Project 5 
 * Closes the fight menu when a battle is won or lost.
 */
public class CloseFightMenu : MonoBehaviour
{
    private OverworldAnxietyEffect worldEffect;
    private PlayerStats playerStats;
    private Text description;

    public Enemy finalBoss;
    public GameObject bossAnim;

    private OpenFightMenu openFMScript;
    private HoverDescriptionVisable hoverDesc;

    public GameObject fightMenu;
    public GameObject gameOverScreen;
    public GameObject youWinScreen;
    public GameObject bossLostScreen;
    public OpenFightMenu fightMenuScript;
    public bool gameOver;
    public bool win = false;
    private bool lost = false;

    public Button attack1;
    public Button attack2;
    public Button attack3;
    public Button attack4;

    private PlayerMovement player;
    private CheckpointTrigger[] checkpoints;
    private bool afterBattle = false;
    private bool keyboardDebugger = false;
    public GameObject loadingObject;
    public SpriteRenderer enemySprite;

    // Start is called before the first frame update
    void Start()
    {
        openFMScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();

        hoverDesc = GameObject.FindGameObjectWithTag("Attack 1").GetComponent<HoverDescriptionVisable>();

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
        fightMenuScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
        description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpoints = new CheckpointTrigger[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            checkpoints[i] = temp[i].GetComponent<CheckpointTrigger>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.attributes[2].value.BaseValue <= 0 && fightMenuScript.enemyEncountered == finalBoss)
        {
            if (!afterBattle)
            {
                fightMenuScript.encounterNum++;
                afterBattle = true;
                StartCoroutine(Win());
            }
        }
        else if (playerStats.attributes[2].value.BaseValue <= 0)
        {
            if (!afterBattle)
            {
                fightMenuScript.encounterNum++;
                afterBattle = true;
                StartCoroutine(BattleOver());
            }
        }
        else if (playerStats.attributes[0].value.BaseValue >= 100 && !gameOver)
        {
            if (!afterBattle)
            {
                afterBattle = true;
                StartCoroutine(Lose());
            }
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (lost)
                {
                    loadingObject.SetActive(true);
                    SceneManager.LoadScene("StartingScreen");
                }
                enemySprite.sortingOrder = 1;
                gameOverScreen.SetActive(false);
                gameOver = false;
                for (int i = 0; i < checkpoints.Length; i++)
                {
                    if (checkpoints[i].currentCheckpoint)
                    {
                        checkpoints[i].Respawn();
                    }
                }
                fightMenu.SetActive(false);
                hoverDesc.mouseOver = false;
                hoverDesc.descriptionCanvas.SetActive(false);

                openFMScript.calmEndMusic.Stop();
                openFMScript.lossMusic.Stop();
                openFMScript.playerAudio.PlayDelayed(0.5f);
            }
        }
        else if (win)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                loadingObject.SetActive(true);
                SceneManager.LoadScene("StartingScreen");
                youWinScreen.SetActive(false);
                win = false;
                fightMenu.SetActive(false);
                hoverDesc.mouseOver = false;
                hoverDesc.descriptionCanvas.SetActive(false);

                openFMScript.calmEndMusic.Stop();
                openFMScript.lossMusic.Stop();
                openFMScript.playerAudio.PlayDelayed(0.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyboardDebugger = true;
        }
    }

    public void EndFightEarly()
    {
        Debug.Log("Ending Encounter");
        StartCoroutine(BattleOverEarly());
    }

    IEnumerator BattleOver()
    {
        keyboardDebugger = false;
        while (!keyboardDebugger)
        {
            yield return new WaitForFixedUpdate();
        }
        keyboardDebugger = false;
        yield return new WaitForEndOfFrame();
        openFMScript.fightMusic.Stop();
        openFMScript.bossMusic.Stop();
        openFMScript.effectSource.PlayOneShot(openFMScript.winBattleSound, .2f);
        description.text = "Problem defeated!\n<Press SPACE To Continue>";
        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        attack4.enabled = false;
        while (!keyboardDebugger)
        {
            yield return new WaitForFixedUpdate();
        }
        openFMScript.playerAudio.PlayDelayed(0.5f);
        attack1.enabled = true;
        attack1.GetComponentInChildren<Text>().enabled = true;
        attack2.enabled = true;
        attack2.GetComponentInChildren<Text>().enabled = true;
        attack3.enabled = true;
        attack3.GetComponentInChildren<Text>().enabled = true;
        attack4.enabled = true;
        attack4.GetComponentInChildren<Text>().enabled = true;
        worldEffect.resetVariables();
        fightMenu.SetActive(false);
        player.canMove = true;
        player.CallStartEffects();
        playerStats.attributes[2].value.BaseValue = 1;
        if (playerStats.attributes[1].value.BaseValue > 0)
        {
            playerStats.attributes[1].value.BaseValue--;
        }
        hoverDesc.mouseOver = false;
        hoverDesc.descriptionCanvas.SetActive(false);
        afterBattle = false;
    }

    IEnumerator Win()
    {
        openFMScript.playerAudio.Stop();
        openFMScript.fightMusic.Stop();
        openFMScript.bossMusic.Stop();

        openFMScript.effectSource.PlayOneShot(openFMScript.winBattleSound, .2f);

        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        attack4.enabled = false;
        win = true;
        description.text = "Is this it..? Is it really over?\n<Press SPACE To Continue>";
        yield return new WaitForSeconds(3);
        enemySprite.sortingOrder = 0;
        youWinScreen.SetActive(true);
        bossAnim.SetActive(false);

        if (!openFMScript.calmEndMusic.isPlaying)
        {
            openFMScript.calmEndMusic.Play();
        }
        hoverDesc.mouseOver = false;
        hoverDesc.descriptionCanvas.SetActive(false);
        afterBattle = false;
    }

    IEnumerator Lose()
    {
        openFMScript.playerAudio.Stop();
        openFMScript.fightMusic.Stop();
        openFMScript.bossMusic.Stop();

        openFMScript.effectSource.PlayOneShot(openFMScript.wrongChoice, .2f);

        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        attack4.enabled = false;
        gameOver = true;
        yield return new WaitForSeconds(openFMScript.enemyEncountered.attackTime * openFMScript.enemyEncountered.numAttacks);
        if (fightMenuScript.enemyEncountered == finalBoss)
        {
            description.text = "You can't keep going on like this...\n<Press SPACE To Continue>";
        }
        else
        {
            description.text = "You are overwhelmed...\n<Press SPACE To Respawn At Last Checkpoint>";
        }
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        enemySprite.sortingOrder = 0;
        if (fightMenuScript.enemyEncountered == finalBoss)
        {
            bossAnim.SetActive(false);
            bossLostScreen.SetActive(true);
            lost = true;
        }
        else
        {
            gameOverScreen.SetActive(true);
        }
        

        if (!openFMScript.lossMusic.isPlaying)
        {
            openFMScript.lossMusic.Play();
        }
        hoverDesc.mouseOver = false;
        hoverDesc.descriptionCanvas.SetActive(false);
        afterBattle = false;
        player.stopEffects(true);
    }

    IEnumerator BattleOverEarly()
    {
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        description.text = "You ran away...";
        fightMenuScript.encounterNum++;
        yield return new WaitForSeconds(2f);
        worldEffect.resetVariables();
        fightMenu.SetActive(false);
        player.canMove = true;
        player.CallStartEffects();
        playerStats.attributes[2].value.BaseValue = 1;

        hoverDesc.mouseOver = false;
        hoverDesc.descriptionCanvas.SetActive(false);

        openFMScript.fightMusic.Stop();
        openFMScript.playerAudio.PlayDelayed(0.5f);
    }
}
