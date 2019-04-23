using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class CollisionDetection : MonoBehaviour
{
    private float playerHealth = .30f;
    public Text healthText;

    //Audio
    public AudioClip audioClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Audio init
        audioSource.clip = audioClip;


        //Initialize health
        //playerHealth = .30f;
        SetHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        
        // Decrease health if enemy hits player
        if (other.gameObject.CompareTag("enemy"))
        {
            print(playerHealth);
            playerHealth -= .01f;
            print(playerHealth);
            SetHealthText();
        }

        
            
            
    }

    void SetHealthText()
    {
        healthText.text = "BAC: " + playerHealth.ToString();
    }

    

}
