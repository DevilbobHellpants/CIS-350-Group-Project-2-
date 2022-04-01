/*
 * Jacob Zydorowicz
 * Project 5
 * Allows clouds to fly towards player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private Transform player;
    public float speed;
    private float minDistance;
    private float range;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, player.position);

        if(range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
