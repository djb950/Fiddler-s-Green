using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Destroy enemy character on collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Character_Pirate_Seaman_01")
        {
            Destroy(collision.gameObject);
        }
    }
}
