using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesTurn : MonoBehaviour
{
    private AttackAction playerTurn;
    private PlayerStats playerSanity;
    // Start is called before the first frame update

    //public bool enemyTurn;

    private OpenFightMenu fightMenu;
    
    void Start()
    {
        playerTurn = GetComponent<AttackAction>();
        fightMenu = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        playerSanity = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enemyTurn()
    {
        StartCoroutine(StartEnemiesTurn());
    }

    IEnumerator StartEnemiesTurn()
    {
        playerTurn.enabled = false;
        Debug.Log("Turn Started");
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

        //yield return new WaitForSeconds(.3f);

        playerSanity.attributes[0].value.BaseValue = (playerSanity.attributes[0].value.BaseValue) + UnityEngine.Random.Range(10, 20);

        //insert enemy attack here

        playerTurn.enabled = true;
    }
}