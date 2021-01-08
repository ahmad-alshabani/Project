using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCamer : MonoBehaviour
{
    public Vector3 myPosition;
    public Transform Heli;
    private float nextTimeToAdjust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        myPosition.y = 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     transform.position = Heli.position + myPosition;
        myPosition.y = -Heli.position.y +19f; 
        /*if (Time.time > nextTimeToAdjust)
            {
                nextTimeToAdjust = Time.time + 1f / 4f;

                if(transform.position.y > 30f)
                {
                myPosition.y = 15f;
                }
                else if (transform.position.y < 20f)
                {
                    myPosition.y = 20f;
                }
                else
                {
                    myPosition.y = -10f;
                }
            }*/
    }
}
