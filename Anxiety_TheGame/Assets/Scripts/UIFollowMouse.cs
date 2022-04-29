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
        Vector3 pos = Input.mousePosition + offset;
        pos.z = BasisObject.position.z;
        MovingObject.position = cam.ScreenToWorldPoint(pos);
    }
}

