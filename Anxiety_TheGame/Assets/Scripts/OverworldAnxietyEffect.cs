/* Caleb Kahn
 * Project 5
 * While the player is in the overworld, this script increases the effects of anxiety over time
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class OverworldAnxietyEffect : MonoBehaviour
{
    public GameObject[] imagePrefabs;
    public bool inBattle = false;//I can take this value from somewhere else
    public Image darknessEffect;
    public CinemachineVirtualCamera cinemachine;
    public GameObject player;
    private float timer = 0;
    private float randomTimer = 0;
    private float cooldownTimer = 0;
    private float minCooldown = 3f;
    private float pov = 3.5f;
    private int randomChance = 120;
    private float effectTimer = 3f;
    private float alpha = 0f;
    private float minAlpha = 0f;
    private float maxAlpha = .1f;
    private float alphaChangeTime = 2f;
    private bool alphaUp = true;

    
    // Start is called before the first frame update
    void Start()
    {
        cinemachine.m_Lens.OrthographicSize = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        randomTimer += Time.deltaTime;
        cooldownTimer += Time.deltaTime;
        if (!inBattle)
        {
            if (timer <= 30)
            {
                minCooldown = 3f - (1f * (timer / 30f));
                pov = 3.5f - (.5f * (timer / 30f));
                cinemachine.m_Lens.OrthographicSize = pov;
                randomChance = (int)(120f - (65f * (timer / 30f)));
                effectTimer = 3f + (1.5f * (timer / 30f));
                minAlpha = .3f * (timer / 30f);
                maxAlpha = .1f + (.4f * (timer / 30f));
            }
            else if (timer <= 60)
            {
                minCooldown = 2f - (1.5f * ((timer - 30f) / 30f));
                pov = 3f - (.5f * ((timer - 30f) / 30f));
                cinemachine.m_Lens.OrthographicSize = pov;
                randomChance = (int)(65f - (40f * ((timer - 30f) / 30f)));
                effectTimer = 4.5f + (1.5f * ((timer - 30f) / 30f));
                minAlpha = .2f + (.3f * ((timer - 30f) / 30f));
                maxAlpha = .5f + (.5f * ((timer - 30f) / 30f));
            }
            else
            {
                effectTimer = 6f + (1.5f * ((timer - 60f) / 30f));
            }
            if (randomTimer >= .1f && cooldownTimer >= minCooldown) {
                randomTimer = 0f;
                if (0 == Random.Range(0, randomChance)) {
                    cooldownTimer = 0f;
                    int num = Random.Range(0, imagePrefabs.Length);
                    GameObject effect = Instantiate(imagePrefabs[num], new Vector2(Random.Range(-8f, 6.0f) + player.transform.position.x, Random.Range(-5f, 5.0f) + player.transform.position.y), imagePrefabs[num].transform.rotation);
                    effect.GetComponent<OverworldEffectMovement>().effectTimer = effectTimer;
                }
            }
            if (alphaUp)
            {
                alpha += (maxAlpha - minAlpha) / alphaChangeTime * Time.deltaTime;
                if (alpha > maxAlpha)
                {
                    alpha = maxAlpha;
                    alphaUp = false;
                }
            }
            else
            {
                alpha -= (maxAlpha - minAlpha) / alphaChangeTime * Time.deltaTime;
                if (alpha < minAlpha)
                {
                    alpha = minAlpha;
                    alphaUp = true;
                }
            }
            darknessEffect.color = new Color(0f, 0f, 0f, alpha);
        }
    }

    public void resetVariables()
    {
        timer = 0;
        randomTimer = 0;
        cooldownTimer = 0;
        minCooldown = 3f;
        pov = 3.5f;
        randomChance = 100;
        effectTimer = 3f;
        alpha = 0f;
        minAlpha = 0f;
        maxAlpha = .1f;
        alphaUp = true;
    }
}
