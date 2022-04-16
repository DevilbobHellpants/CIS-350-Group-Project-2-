using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Project 5 
 * Updates the menu progress bars
 */
public class UpdatingMenuBars : MonoBehaviour
{
    public GameObject enemyHealthBar;
    public GameObject playerAnxietyBar;
    private OpenFightMenu menu;
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        menu = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        playerAnxietyBar.GetComponent<ProgressBar>().maximum = 100;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.GetComponent<ProgressBar>().current = playerStats.attributes[2].value.BaseValue;
        playerAnxietyBar.GetComponent<ProgressBar>().current = playerStats.attributes[0].value.BaseValue;
    }
}
