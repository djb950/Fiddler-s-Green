using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRotation : MonoBehaviour
{


    Light lt;
    Color sunLight = new Color(1f, 0.92f, 0.016f);
    public float speed = 24.0f;
 
    Vector3 angle;
    float rotation = 0f;
    
 
    public enum Axis

    {
        X,
        Y,
        Z
    }
    public Axis axis = Axis.X;
    public bool direction = true;

    void Start()
    {
        angle = transform.localEulerAngles;
        lt = GetComponent<Light>();
        lt.intensity = .4f;

    }

    // Update is called once per frame
    void Update()
    {
        switch (axis)
        {
            case Axis.X:
                transform.localEulerAngles = new Vector3(Rotation(), angle.y, angle.z);
                break;
            case Axis.Y:
                transform.localEulerAngles = new Vector3(angle.x, Rotation(), angle.z);
                break;
            case Axis.Z:
                transform.localEulerAngles = new Vector3(angle.x, angle.y, Rotation());
                break;
        }
      //  lt.color -= (Color.white / speed) * Time.deltaTime;
    }

    float Rotation()
    {
        rotation += speed * Time.deltaTime;

        if (rotation >= 360f)
            rotation -= 360f;

        if (0 <= rotation && rotation <= 45)
            
            lt.intensity += .001f;
            lt.color = sunLight;
        ;

        if (45 < rotation && rotation <= 135)
          //   lt.color = Color.white;
           

        ;

        if (135 < rotation && rotation <= 180)
         //   lt.color = Color.red + Color.yellow;
            lt.intensity -= .001f;
        ;


        if (180 < rotation && rotation <= 360)
            //lt.color = Color.red + Color.blue
        ;
       




        return direction ? rotation : -rotation;
    }
}

