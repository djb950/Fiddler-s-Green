using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform Character; // Target Object to follow
    public float speed = 0.1F; // Enemy speed
    private Vector3 directionOfCharacter;
    private bool challenged = false;// If the enemy is Challenged to follow by the player
    void Update()
    {
        if (challenged)
        {
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized; // Get Direction to Move Towards
            transform.Translate(directionOfCharacter * speed, Space.World);
        }
    }
    // Will be triggered as soon as player would touch the Enemy Object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            challenged = true;
        }
    }
}