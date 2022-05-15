/* Caleb Kahn
 * Project 5
 * Once hit, it makes the list disapear and appear
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class TriggerTile : MonoBehaviour
{
    public GameObject[] disapearList;
    public GameObject[] appearList;
    public bool isTutorialText;
    private bool showedOnce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isTutorialText && !showedOnce)
            {
                showedOnce = true;
                Time.timeScale = 0f;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>().enabled = false;
                for (int i = 0; i < disapearList.Length; i++)
                {
                    disapearList[i].SetActive(false);
                }
                for (int i = 0; i < appearList.Length; i++)
                {
                    appearList[i].SetActive(true);
                }
            }
            else if (!isTutorialText)
            {
                for (int i = 0; i < disapearList.Length; i++)
                {
                    disapearList[i].SetActive(false);
                }
                for (int i = 0; i < appearList.Length; i++)
                {
                    appearList[i].SetActive(true);
                }
            }
        }
    }
}
