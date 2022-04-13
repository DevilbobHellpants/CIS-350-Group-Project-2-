using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker, Jacob Zydorowicz
 * Project 5 
 * Opens the fight menu when player touches a cloud.
 */

//this is supposed to be attached to the cloud prefab- might recode it to be attached to the player because this "FindGameObjectWithTag" isn't finding the game object with tag.
public class OpenFightMenu : MonoBehaviour
{
    private OverworldAnxietyEffect worldEffect;

    public GameObject fightMenu;
    public GameObject nueronEffect;
    public ParticleSystem smokeEffect;
    public Sprite enemyPortrait;
    public Enemy[] enemies;

    public AudioSource playerAudio;
    public AudioClip encounterSound;


    void Start()
    {
        //fightMenu = GameObject.FindGameObjectWithTag("FightMenu");
        worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud"))
        {
            worldEffect.inBattle = true;
            worldEffect.resetVariables();

            nueronEffect.SetActive(false);
            fightMenu.SetActive(true);

            playerAudio.PlayOneShot(encounterSound, .75f);

            if(!smokeEffect.isPlaying)
            {
                StartCoroutine(playSmoke());
            }
               
            Debug.Log("cloud hit");
        }
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        for (int i = 0; i < clouds.Length; i++)
        {
            Destroy(clouds[i]);
        }
    }

    //enemyPortrait.sprite = enemies[1].enemySprite; 
    // was testing something,,, going to wait until i understand the combat system before i mess with the enemies.

    //Plays enemy entry anim and stops time
    IEnumerator playSmoke()
    {
        //yield return new WaitForSeconds(0.5f);

        if (smokeEffect != null)
        {
            playerAudio.PlayOneShot(encounterSound, .75f);
            
            smokeEffect.Play();
            yield return new WaitForSeconds(2);
            Time.timeScale = 0f;
            
            
        }

    }
}
