using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker
 * Project 5 
 * Opens the fight menu when player touches a cloud.
 */

//this is supposed to be attached to the cloud prefab- might recode it to be attached to the player because this "FindGameObjectWithTag" isn't finding the game object with tag.
public class OpenFightMenu : MonoBehaviour
{
    public GameObject fightMenu;
    public Sprite enemyPortrait;
    public Enemy[] enemies;

    void Start()
    { 
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud"))
        {
            fightMenu.SetActive(true);
            Debug.Log("cloud hit");
            Time.timeScale = 0f;
        }
        Destroy(other.gameObject);
    }

    //enemyPortrait.sprite = enemies[1].enemySprite; 
    // was testing something,,, going to wait until i understand the combat system before i mess with the enemies.
}
