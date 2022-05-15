using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TutorialPopups : MonoBehaviour
{
    public GameObject popup;
    private PostProcessVolume processVolume;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        processVolume = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            popup.SetActive(false);
            Time.timeScale = 1f;
            if (player.isBlind)
            {
                processVolume.enabled = true;
            }
        }
    }
}
