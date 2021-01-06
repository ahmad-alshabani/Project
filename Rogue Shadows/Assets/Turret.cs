using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    AudioSource turretFX;
    
    public Transform Helicopter;
    public Vector3 pos;
    public Animator animator;
    float nextFire;
    bool hasReached = false;

    public Transform Target;
    public float RotationSpeed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    //SerializeFields
    [SerializeField] AudioClip rocketLaunch;
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotSpawn;
    [SerializeField] float fireRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        turretFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RocketLaunch();
        if (pos.x < 40f)
        {
            //find the vector pointing from our position to the target
            _direction = (Target.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        }
    }

    void RocketLaunch()
    {
        pos.x = Mathf.Abs(transform.position.x - Helicopter.position.x);
        if (pos.x < 40f  && Time.time > nextFire)
        {
            animator.SetBool("playerReached", true);
            

            if (hasReached == false)
            {
                //hasReached = true;
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            if (!turretFX.isPlaying)
            {
                turretFX.PlayOneShot(rocketLaunch);
            }
        }
        else
        {
            turretFX.Stop();
        }
        
    }
}
