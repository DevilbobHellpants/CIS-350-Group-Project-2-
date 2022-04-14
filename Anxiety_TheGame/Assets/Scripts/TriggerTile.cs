using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTile : MonoBehaviour
{
    public GameObject[] disapearList;
    public GameObject[] appearList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
