using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject fightMenu;

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
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
            StartCoroutine(BattleOver());

        }
        if (playerStats.attributes[0].value.BaseValue > 100)
        {
            description.text = "You are overwhelmed...";
            StartCoroutine(BattleOver());

            //gameOver = true (we don't have a game over state made yet but i'll implement it later
        }
    }

    public void EndFightEarly()
    {
        StartCoroutine(BattleOverEarly());
    }

    IEnumerator BattleOver()
    {
        yield return new WaitForSeconds(5);
        worldEffect.inBattle = false;
        fightMenu.SetActive(false);
        player.canMove = true;
        playerStats.attributes[2].value.BaseValue = 1;
    }

    IEnumerator BattleOverEarly()
    {
        yield return new WaitForSeconds(5);
        worldEffect.inBattle = false;
        fightMenu.SetActive(false);
        player.canMove = true;
        playerStats.attributes[2].value.BaseValue = 1;
    }
}
