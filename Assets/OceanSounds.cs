using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanSounds : MonoBehaviour
{

    //Audio 
    public AudioClip audioClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Audio init
        audioSource.clip = audioClip;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
