using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Name: Anna Breuker
 * Project: Project 7
 * Description: Makes an UI object follow the mouse. Code adapted from https://www.youtube.com/watch?v=JBn9cJvTJnA
 */

public class UIFollowMouse : MonoBehaviour
{

    public RectTransform MovingObject;
    public Vector3 offset;
    public RectTransform BasisObject;
    public Camera cam;


    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        //offset = new Vector3(Screen.width / 8, Screen.height / 12, 0);
        float scale = Screen.width / 800f;
        MovingObject.localScale = Vector3.one * scale;
        offset = new Vector3(-125, -50, 0) * scale;
        Vector3 pos = Input.mousePosition + offset;
        
        pos.z = BasisObject.position.z;
        MovingObject.position = cam.ScreenToWorldPoint(pos);
    }
}

