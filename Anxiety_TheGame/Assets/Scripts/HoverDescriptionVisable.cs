using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Name: Anna Breuker
 * Project: Project 7
 * Description: Makes an UI appear when mouse hovers over attack buttons. Code adapted from https://www.youtube.com/watch?v=uUXmbYVFWME&t=47s
 */

public class HoverDescriptionVisable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject descriptionCanvas;
    private bool mouseOver = false;

    //TODO
    //---going to put code and variables here that reads what
    //   enemy they're fighting/the attack on this button, and
    //   change the description text based on that. 

    void Start()
    {
        descriptionCanvas.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        descriptionCanvas.SetActive(true);
        //Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        descriptionCanvas.SetActive(false);
        //Debug.Log("Mouse exit");
    }
}

