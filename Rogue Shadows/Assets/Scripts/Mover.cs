using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;

    float speed = 150f;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.right * speed;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
