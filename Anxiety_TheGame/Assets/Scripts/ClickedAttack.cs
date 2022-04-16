using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedAttack : MonoBehaviour
{
    private OpenFightMenu enemy;
    public AttackObjects attackButton1;
    public AttackObjects attackButton2;
    public AttackObjects attackButton3;
    public AttackObjects attackButton4;

    [HideInInspector]
    public AttackObjects attack;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
    }

    private void Update()
    {
        if (enemy.enemyNameDisplayed.text == "Glass Eye")
        {
            attack = attackButton1;
        }
        if (enemy.enemyNameDisplayed.text == "Question Air")
        {
            attack = attackButton2;
        }
        if (enemy.enemyNameDisplayed.text == "Liar Smiler")
        {
            attack = attackButton3;
        }
        if (enemy.enemyNameDisplayed.text == "Scramble Sound")
        {
            attack = attackButton4;
        }
    }
}
