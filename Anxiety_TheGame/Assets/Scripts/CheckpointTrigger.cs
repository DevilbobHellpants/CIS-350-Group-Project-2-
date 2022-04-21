/* Caleb Kahn
 * Project 5
 * Used to respawn the player at death
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public Vector3 respawnPoint;
    public bool currentCheckpoint = false;
    public bool isTutorial = false;
    private CheckpointTrigger[] checkpoints;
    public GameObject tutorialCloud;
    private PlayerMovement player;
    private PlayerStats playerStats;
    private int anxiety;
    private OverworldAnxietyEffect worldEffect;
    private OpenFightMenu openFightMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpoints = new CheckpointTrigger[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            checkpoints[i] = temp[i].GetComponent<CheckpointTrigger>();
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        openFightMenu = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenFightMenu>();
        worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !currentCheckpoint)
        {
            for (int i = 0; i < checkpoints.Length; i++)
            {
                checkpoints[i].currentCheckpoint = false;
            }
            currentCheckpoint = true;
            if (playerStats.attributes[0].value.BaseValue != 0)
            {
                playerStats.attributes[0].value.BaseValue /= 2;
            }
            anxiety = playerStats.attributes[0].value.BaseValue;
            openFightMenu.enemyChoice++;
        }
    }

    public void Respawn()
    {
        player.canMove = true;
        worldEffect.resetVariables();
        player.gameObject.transform.position = respawnPoint;
        playerStats.attributes[0].value.BaseValue = anxiety;
        playerStats.attributes[1].value.BaseValue = 0;
        if (isTutorial && openFightMenu.enemyChoice == 1)
        {
            worldEffect.inBattle = true;
            openFightMenu.encounterNum = 0;
            tutorialCloud.SetActive(true);
        }
    }
}
