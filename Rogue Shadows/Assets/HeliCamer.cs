using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCamer : MonoBehaviour
{
    public Vector3 myPosition;
    public Transform Heli;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Heli.position + myPosition;
    }
}
