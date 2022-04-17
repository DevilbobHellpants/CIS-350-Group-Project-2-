using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTutorial : MonoBehaviour
{
    public OpenFightMenu fightMenuScript;
    private Text description;
    public int phase;
    // Start is called before the first frame update
    void Start()
    {
        description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
        fightMenuScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fightMenuScript.encounterNum == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && phase == 0)
            {
                description.text = "The two bars on the bottom left are important! Top is enemy health, bottom is your anxiety. \nPress [space] to continue.";
                phase++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && phase == 1)
            {
                description.text = "If enemy health reaches 0, you overcome the problem. If your anxiety maxes out, you lose. \nPress [space] to continue.";
                phase++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && phase == 2)
            {
                description.text = "Here on this side is how you fight back. Above this box is your 4 options to cope (attacks.) Not all mechanisms are good for you, so choose wisely! \nPress [space] to continue.";
                phase++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && phase == 3)
            {
                description.text = "This box is where you can see everything that's happening. Your attacks, enemy attacks, and other useful information. \nPress [space] to continue.";
                phase++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && phase == 4)
            {
                description.text = "Now, go forth and cope with this problem! \nPress any of the 4 attack buttons to continue.";
                phase++;
            }
        }
    }
}
