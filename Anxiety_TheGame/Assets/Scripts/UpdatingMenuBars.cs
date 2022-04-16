using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //enemyHealthBar.GetComponent<ProgressBar>().maximum = playerStats.attributes[1].value.BaseValue;
        playerAnxietyBar.GetComponent<ProgressBar>().current = playerStats.attributes[0].value.BaseValue;
    }
}
