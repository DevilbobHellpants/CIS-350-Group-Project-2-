using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Anna Breuker
 * Project 5 
 * Closes the fight menu when a battle is won or lost.
 */
public class CloseFightMenu : MonoBehaviour
{
    private OverworldAnxietyEffect worldEffect;
    private PlayerStats playerStats;
    private Text description;

    public Enemy finalBoss;

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

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
        fightMenuScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
        description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats.attributes[2].value.BaseValue <= 0)
        {
            description.text = "Problem defeated!";
            fightMenuScript.encounterNum++;
            StartCoroutine(BattleOver());

        }
        if (playerStats.attributes[2].value.BaseValue <= 0 && fightMenuScript.enemyEncountered == finalBoss)
        {
            description.text = "Is this it..? Is it really over?";
            StartCoroutine(Win());
        }
        if (playerStats.attributes[0].value.BaseValue > 100)
        {
            description.text = "You are overwhelmed...";
            StartCoroutine(Lose());
        }
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void EndFightEarly()
    {
        StartCoroutine(BattleOverEarly());
    }

    IEnumerator BattleOver()
    {
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
        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        attack4.enabled = false;
        gameOver = true;
        yield return new WaitForSeconds(3);
        youWinScreen.SetActive(true);
    }

    IEnumerator Lose()
    {
        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        attack4.enabled = false;
        gameOver = true;
        yield return new WaitForSeconds(3);
        gameOverScreen.SetActive(true);
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
