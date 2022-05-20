using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Noah Trillizio, Anna Breuker, Jacob Zydorowicz
 * Project 5 
 * Controls what happens when an attack button is pressed
 */

public class AttackAction : MonoBehaviour
{
    private PlayerStats playerStats;
    private ClickedAttack clickedAttack;
    private OverworldAnxietyEffect cloudSpwanRate;
    private OpenFightMenu enemy;
    private EnemiesTurn enemyTurn;
    private CloseFightMenu endEncounter;

    private AudioSource MainMusic;

    public int numOfEncounters;
    public bool sameBattle;
    public int numOfDrunkenEncounters;

    private RandomNumGen randomNum;
    private OpenFightMenu openFMScript;

    private Text description;
    private BattleTutorial battleTutorial;
    private bool keyboardBug = false;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private GameObject camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    private PlayerMovement player;
    private GameObject playerAnxietyBar;
    private GameObject enemyHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomNumGen>();
        openFMScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        MainMusic = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        endEncounter = GameObject.FindGameObjectWithTag("FightMenu").GetComponent<CloseFightMenu>();
        enemyTurn = GetComponent<EnemiesTurn>();
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        cloudSpwanRate = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        clickedAttack = GetComponent<ClickedAttack>();
        numOfEncounters = 0;
        sameBattle = false;
        numOfDrunkenEncounters = 0;

        description = GameObject.FindGameObjectWithTag("DescriptionBox").GetComponentInChildren<Text>();
        battleTutorial = FindObjectOfType<BattleTutorial>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerAnxietyBar = GameObject.FindGameObjectWithTag("Player Anxiety Bar");
        enemyHealthBar = GameObject.FindGameObjectWithTag("Enemy Health Bar");
    }


    // gets called when attack button is pressed in the fight menu
    public void playerAttacks(GameObject attackButton)
    {
        battleTutorial.phase = 100;
        if (enemy.enemyNameDisplayed.text == "Glass Eye") //Glass-Eye
        {
            if (attackButton.tag == "Attack 1")
            {
                StartCoroutine(TripleRule());
            }
            else if (attackButton.tag == "Attack 2")
            {
                StartCoroutine(EmotionalSupport());
            }
            else if (attackButton.tag == "Attack 3")
            {
                StartCoroutine(SelfDoubt());
            }
            else
            {
                StartCoroutine(TakeOffGlasses());
            }
        }
        else if (enemy.enemyNameDisplayed.text == "Question Air") //Question-Air
        {
            if (attackButton.tag == "Attack 1")
            {
                StartCoroutine(Visualization());
            }
            else if (attackButton.tag == "Attack 2")
            {
                StartCoroutine(ShiftFocus());
            }
            else if (attackButton.tag == "Attack 3")
            {
                StartCoroutine(ShutDown());
            }
            else
            {
                StartCoroutine(Hide());
            }
        }
        else if (enemy.enemyNameDisplayed.text == "Scramble Sound") //Scrambled Sound
        {
            if (attackButton.tag == "Attack 1")
            {
                StartCoroutine(BoxBreath());
            }
            else if (attackButton.tag == "Attack 2")
            {
                StartCoroutine(BlastMusic());
            }
            else if  (attackButton.tag == "Attack 3")
            {
                StartCoroutine(LeaveTheRoom());
            }
            else
            {
                StartCoroutine(PunchAWall());
            }
        }
        else if (enemy.enemyNameDisplayed.text == "Liar Smiler") //Lier Smiler
        {
            if (attackButton.tag == "Attack 1")
            {
                StartCoroutine(Grounding());
            }
            else if (attackButton.tag == "Attack 2")
            {
                StartCoroutine(GoToSleep());
            }
            else if (attackButton.tag == "Attack 3")
            {
                StartCoroutine(Isolation());
            }
            else
            {
                StartCoroutine(DrinkToForget());
            }
        }
        else /*if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")*/
        {
            Debug.Log("Random Num in AttackAction = " + randomNum.randomNum);
            if (randomNum.randomNum == 1) {//Glass Eye
                if (attackButton.tag == "Attack 1")
                {
                    StartCoroutine(TripleRule());
                }
                else if (attackButton.tag == "Attack 2")
                {
                    StartCoroutine(EmotionalSupport());
                }
                else if (attackButton.tag == "Attack 3")
                {
                    StartCoroutine(SelfDoubt());
                }
                else 
                {
                    StartCoroutine(TakeOffGlasses());
                }
            }
            else if (randomNum.randomNum == 2) {//Question Air
                if (attackButton.tag == "Attack 1")
                {
                    StartCoroutine(Visualization());
                }
                else if (attackButton.tag == "Attack 2")
                {
                    StartCoroutine(ShiftFocus());
                }
                else if (attackButton.tag == "Attack 3")
                {
                    StartCoroutine(ShutDown());
                }
                else
                {
                    StartCoroutine(Hide());
                }
            }
            else if (randomNum.randomNum == 3)//Scrambled Sound
            {
                if (attackButton.tag == "Attack 1")
                {
                    StartCoroutine(BoxBreath());
                }
                else if (attackButton.tag == "Attack 2")
                {
                    StartCoroutine(BlastMusic());
                }
                else if (attackButton.tag == "Attack 3")
                {
                    StartCoroutine(LeaveTheRoom());
                }
                else
                {
                    StartCoroutine(PunchAWall());
                }
            }
            else {//Lier Smiler
                if (attackButton.tag == "Attack 1")
                {
                    StartCoroutine(Grounding());
                }
                else if (attackButton.tag == "Attack 2")
                {
                    StartCoroutine(GoToSleep());
                }
                else if (attackButton.tag == "Attack 3")
                {
                    StartCoroutine(Isolation());
                }
                else if (attackButton.tag == "Attack 4")
                {
                    StartCoroutine(DrinkToForget());
                }
            }
        }
        //clickedAttack.changeAttack = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyboardBug = true;
        }
    }

    IEnumerator TripleRule()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        description.text = "You focus on 3 things you can see, 3 things you can hear, " +
            "and 3 things you can feel, moving 3 different parts of your body." +
            " Taking a deep breath, you feel lighter.\n<Press SPACE To Continue>";
        changeStats(Random.Range(5, 12), playerStats.attributes[0].value.BaseValue / -3);
        enemyTurn.playerTurn(true);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator EmotionalSupport()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        if (Random.value < 0.3f)
        {//Crit
            changeStats(Random.Range(30, 45), -Random.Range(15, 23));
            description.text = "You ask a friend for reassurance. They hug you tightly and you start crying.\n<Press SPACE To Continue>";
        }
        else
        {
            description.text = "You ask a friend for reassurance. They smile and say you look fine.\n<Press SPACE To Continue>";
            changeStats(Random.Range(8, 18), -Random.Range(15, 23));
        }
        enemyTurn.playerTurn(true);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator SelfDoubt()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        changeStats(0, Random.Range(10, 16));
        enemyTurn.playerTurn(false);
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            description.text = "You can't hide from your problems forever.\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(true);
            }
        }
        else if (playerStats.attributes[2].value.BaseValue < openFMScript.enemyEncountered.health)
        {
            description.text = "Maybe they're right... I do look stupid...\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            endEncounter.EndFightEarly();
        }
        else
        {
            description.text = "You doubt yourself and try to leave, but the enemy blocks you.\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(true);
            }
        }
    }

    IEnumerator TakeOffGlasses()
    {
        description.text = "Who needs glasses anyways? Not you, that's for sure.\n<Press SPACE To Continue>";
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        changeStats(Random.Range(3, 8), -Random.Range(15, 20));
        enemyTurn.playerTurn(true);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
        player.isBlind = true;
    }

    IEnumerator Visualization()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        if (Random.value < 0.15f && enemy.enemyNameDisplayed.text != "You" & enemy.enemyNameDisplayed.text != "Your Anxiety")
        {
            description.text = "You imagine yourself away from the enemy, and it works.\n<Press SPACE To Continue>";
            changeStats(0, Random.Range(playerStats.attributes[0].value.BaseValue / 4, playerStats.attributes[0].value.BaseValue / 2));
            enemyTurn.playerTurn(false);
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            endEncounter.EndFightEarly();
        }
        else
        {
            float randomNum = Random.value;
            int attackDammage = 0;
            int minRange = 0;
            int maxRange = 0;
            if (randomNum < .35f)
            {
                description.text = "You try imagining yourself somewhere else. It doesn't work so well...\n<Press SPACE To Continue>";
                attackDammage = Random.Range(1, 11);
                minRange = playerStats.attributes[0].value.BaseValue / 10;
                maxRange = playerStats.attributes[0].value.BaseValue / 4;
            }
            else if (randomNum < .55f)
            {
                description.text = "You imagine yourself at home. Too bad home isn't completely stress free.\n<Press SPACE To Continue>";
                attackDammage = Random.Range(8, 19);
                minRange = playerStats.attributes[0].value.BaseValue / 7;
                maxRange = playerStats.attributes[0].value.BaseValue / 3;
            }
            else if (randomNum < .7f)
            {
                description.text = "You imagine yourself with your friends. It is nice,\n<Press SPACE To Continue>";
                attackDammage = Random.Range(16, 25);
                minRange = playerStats.attributes[0].value.BaseValue / 4;
                maxRange = playerStats.attributes[0].value.BaseValue / 2;
            }
            else
            {
                description.text = "You try imagine yourself defeating the enemy. It seems to have worked...\n<Press SPACE To Continue>";
                attackDammage = Random.Range(25, 35);
                minRange = playerStats.attributes[0].value.BaseValue / 3;
                maxRange = 2 * playerStats.attributes[0].value.BaseValue / 3;
            }

            changeStats(attackDammage, -Random.Range(minRange, maxRange));
            enemyTurn.playerTurn(true);
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(true);
            }
        }
    }

    IEnumerator ShiftFocus()
    {
        description.text = "You shift your focus to something other than what is in front of you.\n<Press SPACE To Continue>";
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            if (playerStats.attributes[2].value.BaseValue % 3 > 0)//Round Up
            {
                changeStats(playerStats.attributes[2].value.BaseValue / 3 + 1, 0);
            }
            else
            {
                changeStats(playerStats.attributes[2].value.BaseValue / 3, 0);
            }
        }
        else
        {
            if (playerStats.attributes[2].value.BaseValue % 2 == 1)//Round Up
            {
                changeStats(playerStats.attributes[2].value.BaseValue / 2 + 1, 0);
            }
            else
            {
                changeStats(playerStats.attributes[2].value.BaseValue / 2, 0);
            }
        }
        enemyTurn.playerTurn(true);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator ShutDown()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        changeStats(0, Random.Range(10, 16));
        enemyTurn.playerTurn(false);
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            description.text = "You can't hide from your problems forever.\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(true);
            }
        }
        else
        {
            description.text = "This isn't worth it- you can't do this. Who wants to actually ask questions anyway?\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            player.isSlow = true;
            endEncounter.EndFightEarly();
        }
    }

    IEnumerator Hide()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        changeStats(0, Random.Range(20, 30));
        enemyTurn.playerTurn(false);
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            description.text = "You can't hide from your problems forever.\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(true);
            }
        }
        else
        {
            player.isHidden = true;
            description.text = "It's too much. Everyone's staring. You can't do this...\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            endEncounter.EndFightEarly();
        }
    }

    IEnumerator BoxBreath()
    {
        description.text = "You breathe in for 4, hold for 4, out for 4, hold for 4. As you repeat, the noise seems fainter.\n<Press SPACE To Continue>";
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            if (openFMScript.enemyEncountered.health % 6 > 2)//Round Up
            {
                changeStats(openFMScript.enemyEncountered.health / 6 + 1, -Random.Range(15, 20));
            }
            else
            {
                changeStats(openFMScript.enemyEncountered.health / 6, -Random.Range(15, 20));
            }
        }
        else
        {
            if (openFMScript.enemyEncountered.health % 4 > 1)//Round Up
            {
                changeStats(openFMScript.enemyEncountered.health / 4 + 1, -Random.Range(15, 20));
            }
            else
            {
                changeStats(openFMScript.enemyEncountered.health / 4, -Random.Range(15, 20));
            }
        }
        enemyTurn.playerTurn(true);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator BlastMusic()
    {
        camera.GetComponent<AudioDistortionFilter>().enabled = true;
        player.isLoud = true;
        playerAnxietyBar.SetActive(false);
        enemyHealthBar.SetActive(false);
        description.text = "You turn the music up. The noise seems fainter.\n<Press SPACE To Continue>";
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        //StartCoroutine(MusicChange());
        //m_MyAudioSource.volume = m_MySliderValue;
        changeStats(Random.Range(10, 18), -Random.Range(28, 35));
        enemyTurn.playerTurn(true);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator LeaveTheRoom()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        enemyTurn.playerTurn(false);
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            description.text = "You can't hide from your problems forever.\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(true);
            }
        }
        else
        {
            player.isIncreasedSpawnRate = true;
            description.text = "You know what? This isn't worth it. You leave the room...\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            endEncounter.EndFightEarly();
        }
    }

    IEnumerator PunchAWall()
    {
        description.text = "You punch a wall out of frustration. ...that kind of hurt.\n<Press SPACE To Continue>";
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        changeStats(-Random.Range(5, 12), -Random.Range(35, 50));
        enemyTurn.playerTurn(false);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator Grounding()//54321
    {
        keyboardBug = false;
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        description.text = "You focus on 5 things you can see.\n<Press SPACE To Continue>";
        if (Random.value > 0.5f)
        {
            changeStats(Random.Range(3, 8), 0);
            enemyTurn.playerTurn(true);
        }
        else
        {
            changeStats(0, -Random.Range(6, 12));
            enemyTurn.playerTurn(false);
        }
        while (!keyboardBug)
        {
            yield return new WaitForEndOfFrame();
        }
        keyboardBug = false;

        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        description.text = "You focus on 4 things you can touch.\n<Press SPACE To Continue>";
        if (Random.value > 0.5f)
        {
            changeStats(Random.Range(3, 8), 0);
            enemyTurn.playerTurn(true);
        }
        else
        {
            changeStats(0, -Random.Range(6, 12));
        }
        while (!keyboardBug)
        {
            yield return new WaitForEndOfFrame();
        }
        keyboardBug = false;

        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        description.text = "You focus on 3 things you can hear.\n<Press SPACE To Continue>";
        if (Random.value > 0.5f)
        {
            changeStats(Random.Range(3, 8), 0);
            enemyTurn.playerTurn(true);
        }
        else
        {
            changeStats(0, -Random.Range(6, 12));
        }
        while (!keyboardBug)
        {
            yield return new WaitForEndOfFrame();
        }
        keyboardBug = false;

        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        description.text = "You focus on 2 things you can smell.\n<Press SPACE To Continue>";
        if (Random.value > 0.5f)
        {
            changeStats(Random.Range(3, 8), 0);
            enemyTurn.playerTurn(true);
        }
        else
        {
            changeStats(0, -Random.Range(6, 12));
        }
        while (!keyboardBug)
        {
            yield return new WaitForEndOfFrame();
        }
        keyboardBug = false;

        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        description.text = "You focus on 1 you can taste. You feel grounded.\n<Press SPACE To Continue>";
        if (Random.value > 0.5f)
        {
            changeStats(Random.Range(3, 8), 0);
            enemyTurn.playerTurn(true);
        }
        else
        {
            changeStats(0, -Random.Range(6, 12));
        }
        while (!keyboardBug)
        {
            yield return new WaitForEndOfFrame();
        }

        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator GoToSleep()
    {
        description.text = "There's nothing a good nap can't fix.\n<Press SPACE To Continue>";
        openFMScript.effectSource.PlayOneShot(openFMScript.positiveAction, .75f);
        changeStats(0, -Random.Range(35, 45));
        enemyTurn.playerTurn(false);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (enemy.enemyNameDisplayed.text != "You" && enemy.enemyNameDisplayed.text != "Your Anxiety" && Random.value > 0.5f)
        {
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(false);
            }
            keyboardBug = false;
            yield return new WaitForSeconds(openFMScript.enemyEncountered.attackTime * openFMScript.enemyEncountered.numAttacks);
            /*description.text = description.text + "\n<Press SPACE To Continue>";
            while (!keyboardBug)
            {
                yield return new WaitForFixedUpdate();
            }*/
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    IEnumerator Isolation()
    {
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        changeStats(0, Random.Range(28, 42));
        enemyTurn.playerTurn(false);
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            description.text = "You can't hide from your problems forever.\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            if (playerStats.attributes[2].value.BaseValue > 0)
            {
                enemyTurn.enemyTurn(true);
            }
        }
        else
        {
            player.isDecreasedSpawnRate = true;
            description.text = "They're right, none of my friends actually care...\n<Press SPACE To Continue>";
            while (!Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForFixedUpdate();
            }
            endEncounter.EndFightEarly();
        }
    }

    IEnumerator DrinkToForget()
    {
        player.isDrunk = true;
        description.text = "Maybe drinking will help?\n<Press SPACE To Continue>";
        openFMScript.effectSource.PlayOneShot(openFMScript.negativeAction, .75f);
        changeStats(0, -Random.Range(25, 40));
        enemyTurn.playerTurn(false);
        while (!Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForFixedUpdate();
        }
        if (playerStats.attributes[2].value.BaseValue > 0)
        {
            enemyTurn.enemyTurn(true);
        }
    }

    /*
    IEnumerator shiftDoubt()
    {
        changeStats();
        if (enemy.enemyNameDisplayed.text == "You" || enemy.enemyNameDisplayed.text == "Your Anxiety")
        {
            Debug.Log("Failed to end encounter");
        }
        else
        {
            endEncounter.EndFightEarly();
        }
    }*/

    public void changeStats(int damage, int anxiety)
    {
        playerStats.attributes[0].value.BaseValue += anxiety;
        if (playerStats.attributes[0].value.BaseValue < 0)
        {
            playerStats.attributes[0].value.BaseValue = 0;
        }
        playerStats.attributes[2].value.BaseValue -= damage;
        if (playerStats.attributes[2].value.BaseValue > openFMScript.enemyEncountered.health)
        {
            playerStats.attributes[2].value.BaseValue = openFMScript.enemyEncountered.health;
        }
        else if (playerStats.attributes[2].value.BaseValue < 0)
        {
            playerStats.attributes[2].value.BaseValue = 0;
        }
        /*Debug.Log(clickedAttack.attack.data.Name);
        for (int i = 0; i < playerStats.attributes.Length; i++)
        {
            for (int j = 0; j < clickedAttack.attack.data.buffs.Length; j++)
            {
                if (playerStats.attributes[i].type == clickedAttack.attack.data.buffs[j].attribute)
                {
                    clickedAttack.attack.data.buffs[j].GenerateValue();
                    if (playerStats.attributes[i] == playerStats.attributes[0])
                    {
                        if (playerStats.attributes[0].value.BaseValue <= ((clickedAttack.attack.data.buffs[j].value) * -1))
                        {
                            playerStats.attributes[i].value.BaseValue = 0;
                        }
                        else
                        {
                            playerStats.attributes[i].value.BaseValue = (playerStats.attributes[i].value.BaseValue) + clickedAttack.attack.data.buffs[j].value;
                        }
                        Debug.Log(string.Concat(playerStats.attributes[i].type, " was updated! Value is now ", playerStats.attributes[i].value.ModifiedValue));
                    }
                    else
                    {
                        playerStats.attributes[i].value.BaseValue = (playerStats.attributes[i].value.BaseValue) + clickedAttack.attack.data.buffs[j].value;
                        Debug.Log(string.Concat(playerStats.attributes[i].type, " was updated! Value is now ", playerStats.attributes[i].value.ModifiedValue));
                    }
                }
            }
        }*/
    }
    /*
    IEnumerator MusicChange()
    {
        MainMusic.volume = .9f;
        yield return new WaitForSeconds(3f);
        MainMusic.volume = .35f;
    }*/
}
