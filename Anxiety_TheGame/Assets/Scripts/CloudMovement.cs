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

    private Vector3 direction;
    private Vector3 leftBound;
    private Vector3 rightBound;

    private void Start()
    {
        leftBound = GameObject.FindGameObjectWithTag("Spawn Left").GetComponent<Transform>().position;
        rightBound = GameObject.FindGameObjectWithTag("Spawn Right").GetComponent<Transform>().position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direction = (player.position - transform.position).normalized;
    }
    // Update is called once per frame
    void Update()
    {
        //finds direction for clouds to move in towards the player
        range = Vector2.Distance(transform.position, player.position);

        if (range > minDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        if (transform.position.x < leftBound.x || transform.position.x > rightBound.x)
        {
            Destroy(gameObject);
         
        }
    }
}
