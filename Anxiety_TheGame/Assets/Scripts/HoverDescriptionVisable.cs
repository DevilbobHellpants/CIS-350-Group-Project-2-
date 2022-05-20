using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Name: Anna Breuker
 * Project: Project 7
 * Description: Makes an UI appear when mouse hovers over attack buttons. Code adapted from https://www.youtube.com/watch?v=uUXmbYVFWME&t=47s
 */

public class HoverDescriptionVisable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject descriptionCanvas;
    public Text displayText;
    private OpenFightMenu enemy;
    public bool mouseOver = false;
    private PlayerStats enemyStats;
    private EnemiesTurn enemiesTurn;

    //TODO
    //---going to put code and variables here that reads what
    //   enemy they're fighting/the attack on this button, and
    //   change the description text based on that. 

    void Start()
    {
        descriptionCanvas.SetActive(false);
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        enemyStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemiesTurn = enemy.attackButtons[0].GetComponent<EnemiesTurn>();
    }

    void Update()
    {
        if (mouseOver && enemiesTurn.Visable())
        {
            descriptionCanvas.SetActive(true);
        }
        else if (mouseOver)
        {
            descriptionCanvas.SetActive(false);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        descriptionCanvas.SetActive(true);
        //displayText.text = "This is a test!";
        //Debug.Log(attackButtons[i].GetComponentInChildren<Text>().text);

        displayText.text = "It's getting hard to focus. You can't remember what this does.";

        if (this.tag == "Attack 1")
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")//333 Grounding
            {
                if (!enemyStats.Lightbulb01pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "\"Ground\" yourself in the present moment: Expel 1 / 3 of your anxiety, slowly chip away at the problem";
                }
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")//Visualisation
            {
                if (!enemyStats.Lightbulb03pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "Visualize yourself somewhere else: Decrease problem health and anxiety a random amount, decrease more anxiety the more you have";
                }
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")//Box Breathing
            {
                if (!enemyStats.Lightbulb05pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "Take a few deep breaths: Slightly decrease anxiety, chip away at the problem by 1/4 max health (less for stronger enemies)";
                }
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")//54321 Grounding
            {
                if (!enemyStats.Lightbulb07pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "\"Ground\" yourself in the present moment: Randomly either slightly decrease anxiety or chip away at the problem 5 times";
                }
            }
        }
        else if (this.tag == "Attack 2")
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")//Emotional Support
            {
                if (!enemyStats.Lightbulb02pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "Gather support from friends: Decrease anxiety, chip away at the problem, chance of critical hit";
                }
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")//Shift Focus
            {
                if (!enemyStats.Lightbulb04pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "Shift your focus elsewhere: Enemy health is halved (less for stronger enemies)";
                }
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")//Blast Music
            {
                if (!enemyStats.Lightbulb06pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "Sometimes loud music drowns out your thoughts: Decrease anxiety, chip away at the problem, temporarily hide anxiety bar";
                }
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")//Go To Sleep
            {
                if (!enemyStats.Lightbulb08pickedup)
                {
                    displayText.text = "Coping skill not unlocked";
                }
                else
                {
                    displayText.text = "Sometimes you just need to sleep it off: Decrease anxiety, chance enemy attacks twice (impossible for stronger enemies to attack twice)";
                }
            }
        }
        else if (this.tag == "Attack 3")
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")//Self Doubt
            {
                displayText.text = "Give in: Increase your anxiety, escape from the encounter if enemy is not at full health";
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")//Shut Down
            {
                displayText.text = "This is too much- shut down: Increase anxiety, end encounter early, temporarily slowed down";
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")//Leave The Room
            {
                displayText.text = "Sometimes you just need to leave the room: End encounter early, temporarily greatly increase cloud spawn rate and speed";
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")//Isolation
            {
                displayText.text = "Who needs friends anyways: Greatly increase anxiety, end encounter early, temporarily lower cloud spawn rate";
            }
        }
        else
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")//Take Off Glasses
            {
                displayText.text = "Glasses are for nerds anyways: Decrease anxiety, slight damage, temporarily blind";
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")//Hide
            {
                displayText.text = "Hide from your problems: Gain some anxiety, end encounter early, temporarily hidden from clouds";
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")//Punch A Wall
            {
                displayText.text = "Get out some pent up rage: Greatly decrease anxiety, but increase problem health";
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")//Drink To Forget
            {
                displayText.text = "Drink some lovely juice: Decreasing your anxiety, temporarily drunken movement";
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        descriptionCanvas.SetActive(false);
    }
}

