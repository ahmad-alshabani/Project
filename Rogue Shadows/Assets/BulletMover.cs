using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed = 45f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.forward * speed;

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
