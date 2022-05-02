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

    private OpenFightMenu openFMScript;

    public GameObject fightMenu;
    public OpenFightMenu fightMenuScript;
    public GameObject gameOverScreen;
    public GameObject youWinScreen;
    public bool gameOver;

    public Button attack1;
    public Button attack2;
    public Button attack3;
    public Button attack4;

    private PlayerMovement player;
    private CheckpointTrigger[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        openFMScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();

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
            description.text = "Is this it..? Is it really over?";
            StartCoroutine(Win());
        }
        else if (playerStats.attributes[2].value.BaseValue <= 0)
        {
            description.text = "Problem defeated!";
            fightMenuScript.encounterNum++;
            StartCoroutine(BattleOver());

        }
        if (playerStats.attributes[0].value.BaseValue > 100 && !gameOver)
        {
            description.text = "You are overwhelmed...";
            StartCoroutine(Lose());
        }
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            }
        }
    }

    public void EndFightEarly()
    {
        StartCoroutine(BattleOverEarly());
    }

    IEnumerator BattleOver()
    {
        openFMScript.fightMusic.Stop();
        openFMScript.bossMusic.Stop();
        openFMScript.effectSource.PlayOneShot(openFMScript.winBattleSound, .2f);
        openFMScript.playerAudio.PlayDelayed(2f);

        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        attack4.enabled = false;
        yield return new WaitForSeconds(2);
        worldEffect.resetVariables();
        fightMenu.SetActive(false);
        player.canMove = true;
        playerStats.attributes[2].value.BaseValue = 1;
        if (playerStats.attributes[1].value.BaseValue > 0)
        {
            playerStats.attributes[1].value.BaseValue--;
        }
        attack1.enabled = true;
        attack2.enabled = true;
        attack3.enabled = true;
        attack4.enabled = true;
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
        gameOver = true;
        yield return new WaitForSeconds(3);
        youWinScreen.SetActive(true);

        if (!openFMScript.calmEndMusic.isPlaying)
        {
            openFMScript.calmEndMusic.Play();
        }
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
        yield return new WaitForSeconds(3);
        gameOverScreen.SetActive(true);

        if (!openFMScript.lossMusic.isPlaying)
        {
            openFMScript.lossMusic.Play();
        }
    }

    IEnumerator BattleOverEarly()
    {
        yield return new WaitForSeconds(2);
        description.text = "You ran away.";
        yield return new WaitForSeconds(3);
        worldEffect.resetVariables();
        fightMenu.SetActive(false);
        player.canMove = true;
        playerStats.attributes[2].value.BaseValue = 1;
    }
}
