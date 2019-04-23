using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordCollider : MonoBehaviour
{
    //Properties
    private float playerHealth;
    public Text healthText;

    //Audio 
    public AudioClip audioClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = .30f;
        SetHealthText2();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Increase health if rum is picked up
        if (other.gameObject.CompareTag("rum"))
        {
            playerHealth += .1f;
            SetHealthText2();
            other.gameObject.SetActive(false);
            audioSource.Play();
        }
    }

    void SetHealthText2()
    {
        healthText.text = "BAC: " + playerHealth.ToString();
    }


}
