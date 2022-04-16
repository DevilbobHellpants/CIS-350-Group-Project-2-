using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI storyText;
    public TextMeshProUGUI continueText;
    private int phase = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && phase == 0)
        {
            titleText.gameObject.SetActive(false);
            storyText.gameObject.SetActive(true);
            continueText.text = "<Space To Start Game>";
            phase++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && phase == 1)
        {
            SceneManager.LoadScene("TilemapTest");
        }
    }
}
