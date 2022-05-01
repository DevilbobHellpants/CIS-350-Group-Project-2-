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
    private bool mouseOver = false;

    //TODO
    //---going to put code and variables here that reads what
    //   enemy they're fighting/the attack on this button, and
    //   change the description text based on that. 

    void Start()
    {
        descriptionCanvas.SetActive(false);
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        descriptionCanvas.SetActive(true);
        displayText.text = "This is a test!";
        //Debug.Log(attackButtons[i].GetComponentInChildren<Text>().text);

        if (this.tag == "Attack 1")
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")
            {
                displayText.text = "\"Ground\" yourself in the present moment, decreasing your anxiety and chipping away at the problem at hand.";
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")
            {
                displayText.text = "\"Ground\" yourself in the present moment, decreasing your anxiety and chipping away at the problem at hand.";
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")
            {
                displayText.text = "Sometimes, loud music can help drown out your thoughts, decreasing your anxiety and chipping away at the problem at hand.";
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")
            {
                displayText.text = "Hide from your problems, anxiety staying the same but ending the encounter early.";
            }

        }
        else if (this.tag == "Attack 2")
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")
            {
                displayText.text = "Gather support from friends, decreasing your anxiety and chipping away at the problem at hand.";
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")
            {
                displayText.text = "Decreasing your anxiety, but at the cost of increasing your problems. And some other... unintended side effects.";
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")
            {
                displayText.text = "Take a few deep breaths, decreasing your anxiety and chipping away at the problem at hand.";
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")
            {
                displayText.text = "Shift your focus elsewhere, decreasing your anxiety and chipping away at the problem at hand.";
            }
        }
        else if (this.tag == "Attack 3")
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")
            {
                displayText.text = "Give in, increase your anxiety, but escape from the encounter early.";
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")
            {
                displayText.text = "Sometimes you just need to sleep it off. Decrease anxiety, but at the cost of a few turns.";
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")
            {
                displayText.text = "Sometimes you just need to leave the room. End encounter early.";
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")
            {
                displayText.text = "This is too much- shut down, increase anxiety, end encounter early.";
            }
        }
        else if (this.tag == "Attack 4")
        {
            if (enemy.enemyNameDisplayed.text == "Glass Eye")
            {
                displayText.text = "Glasses are for nerds anyways. Decrease anxiety, but at the expense of your sight.";
            }
            else if (enemy.enemyNameDisplayed.text == "Liar Smiler")
            {
                displayText.text = "Who needs friends anyways? Increase anxiety, but end encounter early.";
            }
            else if (enemy.enemyNameDisplayed.text == "Scramble Sound")
            {
                displayText.text = "Get out some pent up rage! Decrease anxiety, but increase problem health.";
            }
            else if (enemy.enemyNameDisplayed.text == "Question Air")
            {
                displayText.text = "Visualize yourself somewhere else. Decrease problem health.";
            }
        }

        //displayText = 
        //Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        descriptionCanvas.SetActive(false);
        //Debug.Log("Mouse exit");
    }
}

