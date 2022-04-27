/*
 * Ian Connors
 * Project 5 
 * Animates the checkpoint
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint: MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Opened", false);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
            anim.SetBool("Opened", true);
    }
}
