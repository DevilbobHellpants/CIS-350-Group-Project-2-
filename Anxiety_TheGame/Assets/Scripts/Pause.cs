using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    private PlayerMovement player;
    private PostProcessVolume blind;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        blind = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1f;
                if (player.isBlind && !player.inBattle)
                {
                    blind.enabled = true;
                }
                menu.SetActive(false);
            }
            else
            {
                paused = true;
                Time.timeScale = 0f;
                blind.enabled = false;
                menu.SetActive(true);
            }
        }
    }
}
