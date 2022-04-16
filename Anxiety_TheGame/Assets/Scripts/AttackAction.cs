using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour
{
    private PlayerStats playerStats;
    private ClickedAttack clickedAttack;
    private OverworldAnxietyEffect cloudSpwanRate;
    private OpenFightMenu enemy;

    public int numOfEncounters;
    public bool sameBattle;
    public int numOfDrunkenEncounters;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        cloudSpwanRate = GameObject.FindGameObjectWithTag("Player").GetComponent<OverworldAnxietyEffect>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        clickedAttack = GetComponent<ClickedAttack>();
        numOfEncounters = 0;
        sameBattle = false;
        numOfDrunkenEncounters = 0;
    }

    // gets called when attack button is pressed in the fight menu
    public void playerAttacks(GameObject attackButton)
    {
        if (enemy.enemyNameDisplayed.text == "Glass Eye") //Glass-Eye
        {
            if (attackButton.tag == "Attack 1")
            {
                TripleRule();
            }
            if (attackButton.tag == "Attack 2")
            {
                EmotionalSupport();
            }
            if (attackButton.tag == "Attack 3")
            {
                SelfDoubt();
            }
            if (attackButton.tag == "Attack 4")
            {
                TakeOffGlasses();
            }
        }
        if (enemy.enemyNameDisplayed.text == "Liar Smiler") //Lier Smiler
        {
            if (attackButton.tag == "Attack 1")
            {
                Grounding();
            }
            if (attackButton.tag == "Attack 2")
            {
                DrinkToForget();
            }
            if (attackButton.tag == "Attack 3")
            {
                GoToSleep();
            }
            if (attackButton.tag == "Attack 4")
            {
                Isolation();
            }
        }
        if (enemy.enemyNameDisplayed.text == "Scramble Sound") //Scrambled Sound
        {
            if (attackButton.tag == "Attack 1")
            {
                BlastMusic();
            }
            if (attackButton.tag == "Attack 2")
            {
                BoxBreath();
            }
            if (attackButton.tag == "Attack 3")
            {
                LeaveTheRoom();
            }
            if (attackButton.tag == "Attack 4")
            {
                PunchAWall();
            }
        }
        if (enemy.enemyNameDisplayed.text == "Question Air") //Question-Air
        {
            if (attackButton.tag == "Attack 1")
            {
                Hide();
            }
            if (attackButton.tag == "Attack 2")
            {
                ShiftFocus();
            }
            if (attackButton.tag == "Attack 3")
            {
                ShutDown();
            }
            if (attackButton.tag == "Attack 4")
            {
                Visualization();
            }
        }
    }

    public void TripleRule()
    {
        changeStats();
    }
    public void Grounding()
    {
        changeStats();
    }

    public void BlastMusic()
    {
        changeStats();
        //m_MyAudioSource.volume = m_MySliderValue;
    }

    public void BoxBreath()
    {
        changeStats();
    }

    public void DrinkToForget()
    {
        changeStats();
        if (clickedAttack.attack.data.buffs[2].value == 3)
        {
            //movementMultiplyer = -1;
        }
        //Make when encounter ending making the drinking stat decrease
    }

    public void EmotionalSupport()
    {
        changeStats();
    }

    public void GoToSleep()
    {
        changeStats();
        // skip next two turns
    }

    public void Hide()
    {
        changeStats();
        //Force encounter to end
    }

    public void Isolation()
    {
        changeStats();
        //Force encounter to end
    }

    public void LeaveTheRoom()
    {
        changeStats();
        //Force encounter to end
    }

    public void PunchAWall()
    {
        changeStats();
    }

    public void SelfDoubt()
    {
        changeStats();
    }

    public void shiftDoubt()
    {
        changeStats();
        //Force encounter to end
    }

    public void ShiftFocus()
    {
        changeStats();
    }

    public void ShutDown()
    {
        changeStats();
        cloudSpwanRate.maxCloudSpawnTime = (cloudSpwanRate.maxCloudSpawnTime) - .5f;
        // increase cloud spawn rate
    }

    public void TakeOffGlasses()
    {
        changeStats();
        // blindness?
    }

    public void Visualization()
    {
        changeStats();
        //chance to end encounter
    }

    public void changeStats()
    {
        Debug.Log(clickedAttack.attack.data.Name);
        for (int i = 0; i < playerStats.attributes.Length; i++)
        {
            for (int j = 0; j < clickedAttack.attack.data.buffs.Length; j++)
            {
                if (playerStats.attributes[i].type == clickedAttack.attack.data.buffs[j].attribute)
                {
                    clickedAttack.attack.data.buffs[j].GenerateValue();
                    playerStats.attributes[i].value.BaseValue = (playerStats.attributes[i].value.BaseValue) + clickedAttack.attack.data.buffs[j].value;
                    Debug.Log(string.Concat(playerStats.attributes[i].type, " was updated! Value is now ", playerStats.attributes[i].value.ModifiedValue));
                }
            }
        }
    }
}
