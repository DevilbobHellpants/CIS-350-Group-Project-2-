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
        if (enemy.enemies[0])
        {
            attack = attackButton1;
        }
        if (enemy.enemies[1])
        {
            attack = attackButton2;
        }
        if (enemy.enemies[2])
        {
            attack = attackButton3;
        }
        if (enemy.enemies[3])
        {
            attack = attackButton4;
        }
    }
}
