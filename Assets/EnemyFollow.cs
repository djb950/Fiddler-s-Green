using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class EnemyFollow : MonoBehaviour
{
    //MARK: Properties
    //public BoxCollider Yarr;
    public Transform Player; 
    public int maxDist = 10;
    public int minDist = 5;
    Transform target; //the enemy's target
    int moveSpeed = 2; //move speed
    int rotationSpeed = 2; //speed of turning

    // Audio
    public AudioClip audioClip;
    public AudioSource audioSource;

    // Haptic stuff
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;

    private bool enter = true;
    public int health = 10;
    float delay = 3.0f;

    Transform myTransform; //current transform data of this enemy
    Animator anim;


    void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
        
    }


    void Start()
    {
        //Audio init
        audioSource.clip = audioClip;

        // Animation
        target = GameObject.FindWithTag("Player").transform; //target the player
        anim = GetComponent<Animator>();

    }


    private void OnTriggerEnter(Collider other)
    {
        // Vibrate controllers
        Pulse(0.25f, 100, 15, SteamVR_Input_Sources.LeftHand);
        Pulse(0.25f, 100, 15, SteamVR_Input_Sources.RightHand);

        // Play Audio
        audioSource.Play();

        if (enter && !anim.GetBool("isDead"))
        {
            // Subtract health from enemy
            health -= 10;
            
            // Activate animation transition
            anim.SetBool("isRunning", false);
            anim.SetBool("isDead", true);
            print("Health decreased; trigger");
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<Rigidbody>());
            
        }
    }


    void Update()
    {
        
        // Check the enemy's health
        if (health <= 0 && !anim.GetBool("isDead"))
        {

            //DIE
            anim.SetBool("isDead", true);
            anim.SetBool("isRunning", false);

            //Destroy(target, delay);


        }

        //rotate to look at the player
        if (anim.GetBool("isDead") != true)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }
        

        //move towards the player if within a certain distance
        if (isWithingAppropriateDistance() && anim.GetBool("isDead") != true )
        {

            anim.SetBool("isRunning", true);
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

        }

        // if enemy is too close to player
        else  
        {

            anim.SetBool("isRunning", false);

            // Attack
            anim.SetBool("isAttacking", true);
            
        }

        


    }

    // Method to vibrate controllers
    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);


    }

    private bool isWithingAppropriateDistance()
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