/* Caleb Kahn
 * Project 5
 * Manages the text in the start menu
 */
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
            continueText.text = "<Space To Continue>";
            phase++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && phase == 1)
        {
            storyText.text = "With neurons firing and all kinds of clouded thoughts you piece together that it only makes sense that you’ve landed in your own subconscious.";
            phase++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && phase == 2)
        {
            storyText.text = "If only there was some way to help quell your anxiety and cope with it, but alas you skipped that lecture in psychology due to more pressing class deadlines.";
            phase++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && phase == 3)
        {
            storyText.text = "Without learning to cope with your problems you’ll surely drown in all of the mental madness. Only by overcoming these conflicts will you be at peace (for once) and be able to survive the rest of this semester.";
            continueText.text = "<Space To Start Game>";
            phase++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && phase == 4)
        {
            SceneManager.LoadScene("TilemapTest");
        }
    }
}
