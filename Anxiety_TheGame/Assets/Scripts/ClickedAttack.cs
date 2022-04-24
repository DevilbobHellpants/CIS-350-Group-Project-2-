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

    private void Start()
    {
        changeAttack = true;
        randomNum = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomNumGen>();
        attackAction = GetComponent<AttackAction>();
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
    }

    private void Update()
    {
        //Debug.Log(enemy.enemyNameDisplayed.text);
        if (enemy.enemyNameDisplayed.text == "Glass Eye")
        {
            attack = attackButton1;
        }
        if (enemy.enemyNameDisplayed.text == "Liar Smiler")
        {
            attack = attackButton2;
        }
        if (enemy.enemyNameDisplayed.text == "Scramble Sound")
        {
            attack = attackButton3;
        }
        if (enemy.enemyNameDisplayed.text == "Question Air")
        {
            attack = attackButton4;
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
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[i];
                    }
                    if (randomNum.randomNum == 2)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[4 + i];
                    }
                    if (randomNum.randomNum == 3)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[8 + i];
                    }
                    if (randomNum.randomNum == 4)
                    {
                        enemy.attackButtons[i].GetComponentInChildren<Text>().text = enemy.attackNames[12 + i];
                    }
                }
            }
        }
    }
}
