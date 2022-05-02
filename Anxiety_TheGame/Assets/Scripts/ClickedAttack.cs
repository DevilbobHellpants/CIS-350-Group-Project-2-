using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedAttack : MonoBehaviour
{
    private OpenFightMenu enemy;
    private AttackAction attackAction;
    public AttackObjects attackButton1;
    public AttackObjects attackButton2;
    public AttackObjects attackButton3;
    public AttackObjects attackButton4;

    [HideInInspector]
    public AttackObjects attack;

    [HideInInspector]
    public bool changeAttack;

    private RandomNumGen randomNum;
    private PlayerStats Lightbulbs;
    private EnemiesTurn enemyTurn;

    private void Start()
    {
        changeAttack = true;
        randomNum = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomNumGen>();
        attackAction = GetComponent<AttackAction>();
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        Lightbulbs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemyTurn = GetComponent<EnemiesTurn>();
    }

    private void Update()
    {
        //Debug.Log(enemy.enemyNameDisplayed.text);
        if (enemy.enemyNameDisplayed.text == "Glass Eye")
        {
            if (attackButton1.name == "333Rule")
            {
                if (Lightbulbs.Lightbulb01pickedup == true)
                {
                    Debug.Log("Help me");
                    enemyTurn.Attack1.enabled = false;
                }
            }
            else if (attackButton1.name == "Emotional Support")
            {
                if (Lightbulbs.Lightbulb02pickedup == true)
                {
                    enemyTurn.Attack2.enabled = false;
                }
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
                enemyTurn.Attack2.enabled = true;
                attack = attackButton1;
            }
        }
        if (enemy.enemyNameDisplayed.text == "Liar Smiler")
        {
            if (attackButton1.name == "54321Grounding")
            {
                if (Lightbulbs.Lightbulb03pickedup == true)
                {
                    enemyTurn.Attack1.enabled = false;
                }
            }
            else if (attackButton1.name == "GoToSleep")
            {
                if (Lightbulbs.Lightbulb04pickedup == true)
                {
                    enemyTurn.Attack2.enabled = false;
                }
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
                enemyTurn.Attack2.enabled = true;
                attack = attackButton2;
            }
        }
        if (enemy.enemyNameDisplayed.text == "Scramble Sound")
        {
            if (attackButton1.name == "BlastMusic")
            {
                if (Lightbulbs.Lightbulb05pickedup == true)
                {
                    enemyTurn.Attack1.enabled = false;
                }
            }
            else if (attackButton1.name == "BoxBreathing")
            {
                if (Lightbulbs.Lightbulb06pickedup == true)
                {
                    enemyTurn.Attack2.enabled = false;
                }
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
                enemyTurn.Attack2.enabled = true;
                attack = attackButton3;
            }
        }
        if (enemy.enemyNameDisplayed.text == "Question Air")
        {
            if (attackButton1.name == "Visualization")
            {
                if (Lightbulbs.Lightbulb07pickedup == true)
                {
                    enemyTurn.Attack1.enabled = false;
                }
            }
            else if (attackButton1.name == "ShiftFocus")
            {
                if (Lightbulbs.Lightbulb08pickedup == true)
                {
                    enemyTurn.Attack2.enabled = false;
                }
            }
            else
            {
                enemyTurn.Attack1.enabled = true;
                enemyTurn.Attack2.enabled = true;
                attack = attackButton4;
            }
        }
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            if (changeAttack == true)
            {
                randomNum.makeRandomNum(1,4);
                Debug.Log("Random Num in clickedAttack = " + randomNum);
                if (randomNum.randomNum == 1)
                {
                    //Debug.Log("Random Num = " + 1);
                    attack = attackButton1;
                }
                if (randomNum.randomNum == 2)
                {
                    //Debug.Log("Random Num = " + 2);
                    attack = attackButton2;
                }
                if (randomNum.randomNum == 3)
                {
                    //Debug.Log("Random Num = " + 3);
                    attack = attackButton3;
                }
                if (randomNum.randomNum == 4)
                {
                    //Debug.Log("Random Num = " + 4);
                    attack = attackButton4;
                }
                changeAttack = false;
                for (int i = 0; i < enemy.attackButtons.Length; i++)
                {
                    //Debug.Log(attackButtons[i].GetComponentInChildren<Text>().text);
                    if (randomNum.randomNum == 1)
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
                    if (randomNum.randomNum == 2)
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
                            enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[4 + i];
                        }
                    }
                    if (randomNum.randomNum == 3)
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
                            enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[8 + i];
                        }
                    }
                    if (randomNum.randomNum == 4)
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
                            enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[12 + i];
                        }
                    }
                }
            }
        }
    }
}
