﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Noah Trillizio
 * Project 5 
 * Decides which buttons get which attacks
 */

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

    private void Start()
    {
        changeAttack = true;
        randomNum = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomNumGen>();
        attackAction = GetComponent<AttackAction>();
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        Lightbulbs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        //Debug.Log(enemy.enemyNameDisplayed.text);
        if (enemy.enemyNameDisplayed.text == "Glass Eye")
        {
            attack = attackButton1;
        }
        else if (enemy.enemyNameDisplayed.text == "Liar Smiler")
        {
            attack = attackButton2;
        }
        else if (enemy.enemyNameDisplayed.text == "Scramble Sound")
        {
            attack = attackButton3;
        }
        else if (enemy.enemyNameDisplayed.text == "Question Air")
        {
            attack = attackButton4;
        }
        else if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            if (changeAttack == true)
            {
                randomNum.makeRandomNum(1,5);
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
                for (int i = 0; i < enemy.attackButtons.Length; i++)//Glass Eye
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
                    if (randomNum.randomNum == 2)//Questionair
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
                    if (randomNum.randomNum == 3)//Liar Smiler
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
                    if (randomNum.randomNum == 4)//Scramble Sound
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
                }
            }
        }
    }
}
