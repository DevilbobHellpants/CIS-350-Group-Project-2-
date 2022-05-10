using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
 * Noah Trillizio
 * Project 5 
 * Decides which attacks can and cannot be used
 */

public class UseableAttackHandler : MonoBehaviour
{
    private PlayerStats Lightbulbs;
    private ClickedAttack clickedAttack;
    private EnemiesTurn enemyTurn;
    private OpenFightMenu enemy;
    private RandomNumGen randomNum;

    // Start is called before the first frame update
    void Start()
    {
        clickedAttack = GetComponent<ClickedAttack>();
        enemyTurn = GetComponent<EnemiesTurn>();
        Lightbulbs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        randomNum = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomNumGen>();
    }

    public void OnEnable()
    {
        StartCoroutine(SetUsableAttacks());
    }

    IEnumerator SetUsableAttacks()
    {
        yield return new WaitForSeconds(.02f);
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

        if (enemy.enemyNameDisplayed.text == "Question Air")
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

        if (enemy.enemyNameDisplayed.text == "Question Air")
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

        if (enemy.enemyNameDisplayed.text == "Liar Smiler")
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

        if (enemy.enemyNameDisplayed.text == "Liar Smiler")
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

        if (enemy.enemyNameDisplayed.text == "Scramble Sound")
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

        if (enemy.enemyNameDisplayed.text == "Scramble Sound")
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

        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            if (randomNum.randomNum == 1)
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

            if (randomNum.randomNum == 1)
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

            if (randomNum.randomNum == 2)
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

            if (randomNum.randomNum == 2)
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

            if (randomNum.randomNum == 3)
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

            if (randomNum.randomNum == 3)
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

            if (randomNum.randomNum == 4)
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

            if (randomNum.randomNum == 4)
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
        SetAttackNames();
    }

    public void SetAttackNames()
    {
        if (enemyTurn.Attack4.GetComponentInChildren<Text>().text == "")
        {
            for (int i = 0; i < enemy.attackButtons.Length; i++)
            {
                //Debug.Log(attackButtons[i].GetComponentInChildren<Text>().text);
                if (enemy.enemyNameDisplayed.text == "Glass Eye")
                {
                    if (Lightbulbs.Lightbulb01pickedup == false && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (Lightbulbs.Lightbulb02pickedup == false && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[i];
                    }
                }
                if (enemy.enemyNameDisplayed.text == "Liar Smiler")
                {
                    if (Lightbulbs.Lightbulb05pickedup == false && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (Lightbulbs.Lightbulb06pickedup == false && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[4 + i];
                    }
                }
                if (enemy.enemyNameDisplayed.text == "Scramble Sound")
                {
                    if (Lightbulbs.Lightbulb07pickedup == false && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (Lightbulbs.Lightbulb08pickedup == false && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[8 + i];
                    }
                }
                if (enemy.enemyNameDisplayed.text == "Question Air")
                {
                    if (Lightbulbs.Lightbulb03pickedup == false && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (Lightbulbs.Lightbulb04pickedup == false && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[12 + i];
                    }
                }
            }
        }
    }
}
