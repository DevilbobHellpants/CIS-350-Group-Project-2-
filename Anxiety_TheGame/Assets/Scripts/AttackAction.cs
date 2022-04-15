using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour
{
    private PlayerStats playerStats;
    private ClickedAttack clickedAttack;

    public int numOfEncounters;
    public bool sameBattle;
    public int numOfDrunkenEncounters;

    private OverworldAnxietyEffect cloudSpwanRate;

    // Start is called before the first frame update
    void Start()
    {
        cloudSpwanRate = GameObject.FindGameObjectWithTag("Player").GetComponent<OverworldAnxietyEffect>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        clickedAttack = GetComponent<ClickedAttack>();
        numOfEncounters = 0;
        sameBattle = false;
        numOfDrunkenEncounters = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Meditate();
        }
    }

    public void Meditate()
    {
        //playerStats.attributes[0].value.BaseValue = (playerStats.attributes[0].value.BaseValue)
        //playerStats.attributes[0].value.BaseValue = (playerStats.attributes[0].value.BaseValue) + clickedAttack.attack.data.buffs[0].value;
        //Debug.Log(string.Concat(playerStats.attributes[0].type, " was updated! Value is now ", playerStats.attributes[0].value.ModifiedValue));
        for (int i = 0; i < playerStats.attributes.Length; i++)
        {
            if (playerStats.attributes[0].type == clickedAttack.attack.data.buffs[0].attribute)
            {
                clickedAttack.attack.data.buffs[0].GenerateValue();
                playerStats.attributes[0].value.BaseValue = (playerStats.attributes[0].value.BaseValue) + clickedAttack.attack.data.buffs[0].value;
                Debug.Log(string.Concat(playerStats.attributes[0].type, " was updated! Value is now ", playerStats.attributes[0].value.ModifiedValue));
            }
        }
    }

    public void TripleRule()
    {
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
    public void Grounding()
    {
        for (int i = 0; i < playerStats.attributes.Length; i++)
        {
            for (int j = 0; j < clickedAttack.attack.data.buffs.Length; j++)
            {
                if (playerStats.attributes[i].type == clickedAttack.attack.data.buffs[j].attribute)
                {
                    //clickedAttack.attack.data.buffs[j].GenerateValue();
                    playerStats.attributes[i].value.BaseValue = (playerStats.attributes[i].value.BaseValue) + clickedAttack.attack.data.buffs[j].value;
                    Debug.Log(string.Concat(playerStats.attributes[i].type, " was updated! Value is now ", playerStats.attributes[i].value.ModifiedValue));
                }
            }
        }
    }

    public void BlastMusic()
    {
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
        //m_MyAudioSource.volume = m_MySliderValue;
    }

    public void BoxBreath()
    {
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

    public void DrinkToForget()
    {
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
        if (clickedAttack.attack.data.buffs[2].value == 3)
        {
            //movementMultiplyer = -1;
        }
        //Make when encounter ending making the drinking stat decrease
    }

    public void EmotionalSupport()
    {
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

    public void GoToSleep()
    {
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
        // skip next two turns
    }

    public void Hide()
    {
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
        //Force encounter to end
    }

    public void Isolation()
    {
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
        //Force encounter to end
    }

    public void LeaveTheRoom()
    {
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
        //Force encounter to end
    }

    public void PunchAWall()
    {
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

    public void SelfDoubt()
    {
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

    public void shiftDoubt()
    {
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
        //Force encounter to end
    }

    public void ShiftFocus()
    {
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

    public void ShutDown()
    {
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
        cloudSpwanRate.maxCloudSpawnTime = (cloudSpwanRate.maxCloudSpawnTime) - .5f;
        // increase cloud spawn rate
    }

    public void TakeOffGlasses()
    {
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
        // blindness?
    }

    public void Visualization()
    {
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
        //chance to end encounter
    }
}
