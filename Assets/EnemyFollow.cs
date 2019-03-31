using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //MARK: Properties
    public Transform Player;
    public int maxDist = 10;
    public int minDist = 5;
    Transform target; //the enemy's target
    int moveSpeed = 2; //move speed
    int rotationSpeed = 2; //speed of turning

    Transform myTransform; //current transform data of this enemy

    Animator anim;


    void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        
        //rotate to look at the player
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);


        //move towards the player if within a certain distance
        if (isWithingAppropriateDistance() )
        {

            // If enemy is not running
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                anim.CrossFade("Run",0);
                
            }
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

        }

        

        // if enemy is too close to player
        else  
        {
            
            anim.CrossFade("Idle", 0.1f);
            
        }

        bool isWithingAppropriateDistance()
        {
            bool result = false;

            // distance between player and enemy is greater than 2 and less than or equal to 10
            if (Vector3.Distance(transform.position, Player.position) > minDist && Vector3.Distance(transform.position, Player.position) <= maxDist)
            {
                result = true;
            }
            return result;
            
        }

        


        
        




    }










}