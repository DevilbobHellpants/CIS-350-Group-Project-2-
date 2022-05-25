using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using DigitalRuby.SimpleLUT;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    private PlayerMovement player;
    private PostProcessVolume blind;
    public bool paused = false;
    public GameObject tutorialPopup;
    private SimpleLUT cameraLUT;
    public Animator enemyAnimation;
    private SpriteRenderer enemySprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        blind = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>();
        cameraLUT = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SimpleLUT>();
        enemySprite = enemyAnimation.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                UnPause();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0f;
        blind.enabled = false;
        menu.SetActive(true);
        cameraLUT.TintColor = Color.white;
        cameraLUT.Contrast = 0f;
        cameraLUT.Sharpness = 0f;
        enemyAnimation.speed = 0f;
        enemySprite.sortingOrder = 0;
    }

    public void UnPause()
    {
        paused = false;
        if (player.isBlind && !player.inBattle && !tutorialPopup.activeSelf)
        {
            blind.enabled = true;
        }
        if (!tutorialPopup.activeSelf)
        {
            Time.timeScale = 1f;
        }
        menu.SetActive(false);
        enemyAnimation.speed = 1f;
        enemySprite.sortingOrder = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartingScreen");
    }
}
