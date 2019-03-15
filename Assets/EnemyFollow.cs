﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Transform target; //the enemy's target
    int moveSpeed = 2; //move speed
    int rotationSpeed = 2; //speed of turning

    Transform myTransform; //current transform data of this enemy


    void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player


    }


    void Update()
    {
        //rotate to look at the player
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);


        //move towards the player
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;




    }










}