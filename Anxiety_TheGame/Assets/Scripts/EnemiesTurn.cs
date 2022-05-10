using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Noah Trillizio
 * Project 5 
 * Controls what happens when the enemie takes there turn
 */

public class EnemiesTurn : MonoBehaviour
{
    private AttackAction playerTurn;
    private PlayerStats playerSanity;
    private ClickedAttack clickedAttack;

    public Button Attack1;
    public Button Attack2;
    public Button Attack3;
    public Button Attack4;

    private Text description;
    // Start is called before the first frame update

    //public bool enemyTurn;

    private OpenFightMenu fightMenu;
    
    void Start()
    {
        clickedAttack = GetComponent<ClickedAttack>();
        playerTurn = GetComponent<AttackAction>();
        fightMenu = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        playerSanity = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enemyTurn()
    {
        StartCoroutine(StartEnemiesTurn());
    }

    public void enemyTripleTurn()
    {
        StartCoroutine(StartEnemiesTripleTurn());
    }

    IEnumerator StartEnemiesTurn()
    {
        Attack1.enabled = false;
        Attack1.GetComponentInChildren<Text>().enabled = false;
        Attack2.enabled = false;
        Attack2.GetComponentInChildren<Text>().enabled = false;
        Attack3.enabled = false;
        Attack3.GetComponentInChildren<Text>().enabled = false;
        Attack4.enabled = false;
        Attack4.GetComponentInChildren<Text>().enabled = false;
        //Debug.Log("Turn Started");
        fightMenu.enemyPortrait.enabled = false;
        yield return new WaitForSeconds(.15f);
        fightMenu.enemyPortrait.enabled = true;
        yield return new WaitForSeconds(.15f);
        fightMenu.enemyPortrait.enabled = false;
        yield return new WaitForSeconds(.15f);
        fightMenu.enemyPortrait.enabled = true;
        yield return new WaitForSeconds(.15f);
        fightMenu.enemyPortrait.enabled = false;
        yield return new WaitForSeconds(.15f);
        fightMenu.enemyPortrait.enabled = true;

        yield return new WaitForSeconds(2f);
        if (fightMenu.description.text != "You ran away.") //making sure the enemy doesn't attack after the player runs away.
        {
            //text indicating what the enemy attack is
            int randomDescription = Random.Range(0, fightMenu.enemyEncountered.attackDescriptions.Length);
            description.text = fightMenu.enemyEncountered.attackDescriptions[randomDescription];

            if (fightMenu.enemyEncountered.enemyName == "Final Boss")
            {
                playerSanity.attributes[0].value.BaseValue = (playerSanity.attributes[0].value.BaseValue) + UnityEngine.Random.Range(20, 50);  //enemy attack
            }
            else
            {
                playerSanity.attributes[0].value.BaseValue = (playerSanity.attributes[0].value.BaseValue) + UnityEngine.Random.Range(10, 30);  //enemy attack
            }

            Debug.Log(playerSanity.attributes[0].value.BaseValue);
        }
        Attack1.enabled = true;
        Attack1.GetComponentInChildren<Text>().enabled = true;
        Attack2.enabled = true;
        Attack2.GetComponentInChildren<Text>().enabled = true;
        Attack3.enabled = true;
        Attack3.GetComponentInChildren<Text>().enabled = true;
        Attack4.enabled = true;
        Attack4.GetComponentInChildren<Text>().enabled = true;
        clickedAttack.changeAttack = true;
    }

    IEnumerator StartEnemiesTripleTurn()
    {
        Attack1.enabled = false;
        Attack2.enabled = false;
        Attack3.enabled = false;
        Attack4.enabled = false;
        playerTurn.enabled = false;
        //Debug.Log("Turn Started");

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(2f);

            int randomDescription = Random.Range(0, fightMenu.enemyEncountered.attackDescriptions.Length);
            description.text = fightMenu.enemyEncountered.attackDescriptions[randomDescription];

            playerSanity.attributes[0].value.BaseValue = (playerSanity.attributes[0].value.BaseValue) + UnityEngine.Random.Range(10, 30); //enemy attack
        }

        playerTurn.enabled = true;
        Attack1.enabled = true;
        Attack2.enabled = true;
        Attack3.enabled = true;
        Attack4.enabled = true;
        clickedAttack.changeAttack = true;
    }
}