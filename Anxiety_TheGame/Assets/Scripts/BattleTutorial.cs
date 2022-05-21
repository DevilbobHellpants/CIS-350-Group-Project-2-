using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTutorial : MonoBehaviour
{
    public OpenFightMenu fightMenuScript;
    private Text description;
    public int phase;
    public Pause pause;

    // Start is called before the first frame update
    void Start()
    {
        description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
        fightMenuScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fightMenuScript.encounterNum == 0 && Input.GetKeyDown(KeyCode.Space) && !pause.paused)
        {
            if (phase == 0)
            {
                description.text = "The two bars on the bottom left are important! The top shows the enemy health, the bottom shows your anxiety.\n<Press SPACE To Continue>";
                phase++;
            }
            else if (phase == 1)
            {
                description.text = "If enemy health reaches 0, you overcome the problem. If your anxiety maxes out, you lose.\n<Press SPACE To Continue>";
                phase++;
            }
            else if (phase == 2)
            {
                description.text = "This side alllows you fight back! The 4 buttons are your options to cope (attack). Not all coping mechanisms are open right away.\n<Press SPACE To Continue>";
                phase++;
            }
            else if (phase == 3)
            {
                description.text = "Some attacks have temporary effects outside of combat, so be mindful of those.\n<Press SPACE To Continue>";
                phase++;
            }
            else if (phase == 4)
            {
                description.text = "You can hover over the individual coping mechanisms to see more details about what they will do.\n<Press SPACE To Continue>";
                phase++;
            }
            else if (phase == 5)
            {
                description.text = "This box is where you can see everything that's happening. Your attacks, enemy attacks, and other useful information.\n<Press SPACE To Continue>";
                phase++;
            }
            else if (phase == 6)
            {
                description.text = "Now, go forth and cope with this problem!\n<Click An Attack To Continue>";
                phase++;
            }
        }
    }
}
