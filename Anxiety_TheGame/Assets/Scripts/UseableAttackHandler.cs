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
    
    public void CallSetUsableAttacks()
    {
        StartCoroutine(SetUsableAttacks());
    }

    IEnumerator SetUsableAttacks()
    {
        yield return new WaitForEndOfFrame();
        if (enemy.enemyNameDisplayed.text == "Glass Eye")
        {
            enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb01pickedup;
            enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb02pickedup;
        }
        else if (enemy.enemyNameDisplayed.text == "Question Air")
        {
            enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb03pickedup;
            enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb04pickedup;
        }
        else if (enemy.enemyNameDisplayed.text == "Scramble Sound")
        {
            enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb05pickedup;
            enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb06pickedup;
        }
        else if (enemy.enemyNameDisplayed.text == "Liar Smiler")
        {
            enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb07pickedup;
            enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb08pickedup;
        }
        else//Boss
        {
            if (randomNum.randomNum == 1)
            {
                enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb01pickedup;
                enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb02pickedup;
            }
            else if (randomNum.randomNum == 2)
            {
                enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb03pickedup;
                enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb04pickedup;
            }
            else if (randomNum.randomNum == 3)
            {
                enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb05pickedup;
                enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb06pickedup;
            }
            else {
                enemyTurn.Attack1.enabled = Lightbulbs.Lightbulb07pickedup;
                enemyTurn.Attack2.enabled = Lightbulbs.Lightbulb08pickedup;
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
                    if (!Lightbulbs.Lightbulb01pickedup && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (!Lightbulbs.Lightbulb02pickedup && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[i];
                    }
                }
                else if (enemy.enemyNameDisplayed.text == "Question Air")
                {
                    if (!Lightbulbs.Lightbulb03pickedup && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (!Lightbulbs.Lightbulb04pickedup && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[12 + i];
                    }
                }
                else if (enemy.enemyNameDisplayed.text == "Scramble Sound")
                {
                    if (!Lightbulbs.Lightbulb05pickedup && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (!Lightbulbs.Lightbulb06pickedup && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[8 + i];
                    }
                }
                else //Liar Smiler
                {
                    if (!Lightbulbs.Lightbulb07pickedup && i == 0)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else if (!Lightbulbs.Lightbulb08pickedup && i == 1)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = "";
                    }
                    else
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[4 + i];
                    }
                }
            }
        }
    }
}
