using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTrggerTile : MonoBehaviour
{
    public GameObject[] inOrderAppearTiles;
    public float waitTime = 1f;

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
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
        StartCoroutine(RemoveDarkness());
        for (int i = 0; i < clouds.Length; i++)
        {
            Destroy(clouds[i]);
        }
        player.canMove = false;
        worldEffect.inBattle = true;
        for (int i = 0; i < inOrderAppearTiles.Length; i++)
        {
            inOrderAppearTiles[i].SetActive(true);
            yield return new WaitForSeconds(waitTime);
        }
        player.canMove = true;
        gameObject.SetActive(false);
    }

    IEnumerator RemoveDarkness()
    {
        Image darknessEffect = GameObject.FindGameObjectWithTag("Darkness Effect").GetComponent<Image>();
        float timer = 0;
        float darknessAlpha = darknessEffect.color.a;
        while (timer < 1f)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            darknessEffect.color = new Color(0f, 0f, 0f, darknessAlpha * (1f - timer) / 1f);
        }
        darknessEffect.color = new Color(0f, 0f, 0f, 0f);
    }
}
