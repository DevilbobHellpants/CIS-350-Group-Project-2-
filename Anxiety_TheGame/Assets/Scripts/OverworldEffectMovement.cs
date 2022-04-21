/* Caleb Kahn
 * Project 5
 * Allows effects to move
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldEffectMovement : MonoBehaviour
{
    public float speed = 3f;
    public float effectTimer = 5f;
    public Image image;
    public Text text;
    public bool inBattle = true;

    private float timer = 0f;
    private Vector3 direction;

    private void Start()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        speed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inBattle)
        {
            timer += Time.deltaTime;
            if (timer >= effectTimer)
            {
                Destroy(this.gameObject);
            }
            transform.position += direction * speed * Time.deltaTime;
            if (image == null)
            {
                if (effectTimer < 5f)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - (Mathf.Abs(effectTimer / 2 - timer) / (effectTimer / 2)));
                }
                else
                {
                    if (timer < 2.5f)
                    {
                        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - (2.5f - timer) / (2.5f));
                    }
                    else if (effectTimer - 2.5f < timer)
                    {
                        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - (2.5f - (effectTimer - timer)) / (2.5f));
                    }
                }
            }
            else
            {
                if (effectTimer < 5f)
                {
                    image.color = new Color(1f, 1f, 1f, 1f - (Mathf.Abs(effectTimer / 2 - timer) / (effectTimer / 2)));
                    text.color = new Color(0f, 0f, 0f, 1f - (Mathf.Abs(effectTimer / 2 - timer) / (effectTimer / 2)));
                }
                else
                {
                    if (timer < 2.5f)
                    {
                        image.color = new Color(1f, 1f, 1f, 1f - (2.5f - timer) / (2.5f));
                        text.color = new Color(0f, 0f, 0f, 1f - (2.5f - timer) / (2.5f));
                    }
                    else if (effectTimer - 2.5f < timer)
                    {
                        image.color = new Color(1f, 1f, 1f, 1f - (2.5f - (effectTimer - timer)) / (2.5f));
                        text.color = new Color(0f, 0f, 0f, 1f - (2.5f - (effectTimer - timer)) / (2.5f));
                    }
                }
            }
        }
    }
}