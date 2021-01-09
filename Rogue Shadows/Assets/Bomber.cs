using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    float nextFire;
    public Vector3 pos, heliPos;
    public Transform Target;
    bool hasReached = false;
    public Animator animator;

    [SerializeField] GameObject missile;
    [SerializeField] Transform shotSpawn;
    [SerializeField] float fireRate = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        pos.x = Mathf.Abs(transform.position.x - Target.position.x);
        if (pos.x < 70f && Time.time > nextFire)
        { 
               animator.SetBool("playerReached", true);
            nextFire = Time.time + fireRate;
            if (Target.position.x > 1050f && Target.position.x < 1340f)
            {
                Instantiate(missile, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }
}
