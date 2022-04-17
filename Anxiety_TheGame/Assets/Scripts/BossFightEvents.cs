using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Project 5 
 * This script controls events within the boss fight.
 */
public class BossFightEvents : MonoBehaviour
{
    public Enemy finalBoss;
    private OpenFightMenu fightMenu;
    private PlayerStats enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        fightMenu = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        enemyStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fightMenu.enemyEncountered == finalBoss)
        {
            if (enemyStats.attributes[2].value.BaseValue <= 100)
            {
                fightMenu.enemyNameDisplayed.text = "Your Anxiety"; //changes the enemy name halfway through the fight.
            }
        }
    }
}
