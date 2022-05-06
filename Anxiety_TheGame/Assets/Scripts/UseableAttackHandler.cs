using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UseableAttackHandler : MonoBehaviour
{
    private PlayerStats Lightbulbs;
    private ClickedAttack clickedAttack;
    private EnemiesTurn enemyTurn;
    private OpenFightMenu enemy;

    // Start is called before the first frame update
    void Start()
    {
        clickedAttack = GetComponent<ClickedAttack>();
        enemyTurn = GetComponent<EnemiesTurn>();
        Lightbulbs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.enemyNameDisplayed.text == "Glass Eye")
        {
            if (Lightbulbs.Lightbulb01pickedup == false)
            {
                enemyTurn.Attack1.enabled = false;
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
            }
        }

        if (enemy.enemyNameDisplayed.text == "Glass Eye")
        {
            if (Lightbulbs.Lightbulb02pickedup == false)
            {
                enemyTurn.Attack2.enabled = false;
            }
            else
            {
                enemyTurn.Attack2.enabled = true;
            }
        }

        if (enemy.enemyNameDisplayed.text == "Liar Smiler")
        {
            if (Lightbulbs.Lightbulb03pickedup == false)
            {
                enemyTurn.Attack1.enabled = false;
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
            }
        }

        if (enemy.enemyNameDisplayed.text == "Liar Smiler")
        {
            if (Lightbulbs.Lightbulb04pickedup == false)
            {
                enemyTurn.Attack2.enabled = false;
            }
            else
            {
                enemyTurn.Attack2.enabled = true;
            }
        }

        if (enemy.enemyNameDisplayed.text == "Scramble Sound")
        {
            if (Lightbulbs.Lightbulb05pickedup == false)
            {
                enemyTurn.Attack1.enabled = false;
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
            }
        }

        if (enemy.enemyNameDisplayed.text == "Scramble Sound")
        {
            if (Lightbulbs.Lightbulb06pickedup == false)
            {
                enemyTurn.Attack2.enabled = false;
            }
            else
            {
                enemyTurn.Attack2.enabled = true;
            }
        }

        if (enemy.enemyNameDisplayed.text == "Question Air")
        {
            if (Lightbulbs.Lightbulb07pickedup == false)
            {
                enemyTurn.Attack1.enabled = false;
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
            }
        }

        if (enemy.enemyNameDisplayed.text == "Question Air")
        {
            if (Lightbulbs.Lightbulb08pickedup == false)
            {
                enemyTurn.Attack2.enabled = false;
            }
            else
            {
                enemyTurn.Attack2.enabled = true;
            }
        }
    }
}
