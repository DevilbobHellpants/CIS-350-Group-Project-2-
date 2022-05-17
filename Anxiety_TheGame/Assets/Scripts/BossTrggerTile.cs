/* Caleb Kahn
 * Project 5
 * Slowly adds tiles and resets some variables
 */
using DigitalRuby.SimpleLUT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTrggerTile : MonoBehaviour
{
    public GameObject[] inOrderAppearTiles;
    public float waitTime = 1f;
    public SimpleLUT cameraLUT;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SlowlyAddTiles());
        }
    }

    IEnumerator SlowlyAddTiles()
    {
        PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        OverworldAnxietyEffect worldEffect = GameObject.FindGameObjectWithTag("AnxietyEffect").GetComponent<OverworldAnxietyEffect>();
        player.stopEffects(false);
        StartCoroutine(RemoveDarkness());
        player.canMove = false;
        player.resetStats();
        player.gameObject.GetComponent<OpenFightMenu>().startingBattle = true;
        worldEffect.inBattle = true;
        for (int i = 0; i < inOrderAppearTiles.Length; i++)
        {
            inOrderAppearTiles[i].SetActive(true);
            yield return new WaitForSeconds(waitTime);
        }
        player.canMove = true;
        player.gameObject.GetComponent<OpenFightMenu>().startingBattle = false;
        gameObject.SetActive(false);
    }

    IEnumerator RemoveDarkness()
    {
        //Image darknessEffect = GameObject.FindGameObjectWithTag("Darkness Effect").GetComponent<Image>();
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        GameObject[] effects = GameObject.FindGameObjectsWithTag("PhysicalAnxietyEffect");
        float[] alpha = new float[effects.Length];
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].GetComponent<OverworldEffectMovement>().inBattle = true;
            alpha[i] = effects[i].GetComponent<SpriteRenderer>().color.a;
        }
        for (int i = 0; i < clouds.Length; i++)
        {
            clouds[i].GetComponent<CloudMovement>().canDie = false;
        }
        float timer = 0;
        //float darknessAlpha = darknessEffect.color.a;
        float darknessAlpha = -cameraLUT.Brightness;
        while (timer < waitTime)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            //darknessEffect.color = new Color(0f, 0f, 0f, darknessAlpha * (waitTime - timer) / waitTime);
            cameraLUT.Brightness = -darknessAlpha * (waitTime - timer) / waitTime;
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (waitTime - timer) / waitTime);
            }
            for (int i = 0; i < effects.Length; i++)
            {
                effects[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha[i] * (waitTime - timer) / waitTime);
            }
        }
        //darknessEffect.color = new Color(0f, 0f, 0f, 0f);
        cameraLUT.Brightness = 0;
        for (int i = 0; i < clouds.Length; i++)
        {
            Destroy(clouds[i]);
        }
        for (int i = 0; i < effects.Length; i++)
        {
            Destroy(effects[i]);
        }
    }
}
