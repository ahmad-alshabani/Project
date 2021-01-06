﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController character;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    bool inputEnabled = false;

    public bool inHelicopter = true;

    public Vector3 myPos;
    public Transform Helicopter;

    AudioSource playerFX;
    [SerializeField] AudioClip footSteps;

    // Update is called once per frame

    private void Start()
    {
        character = GetComponent<CharacterController>();
        playerFX = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (inHelicopter && Input.GetKey(KeyCode.E)){
            transform.position = Helicopter.position + myPos;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speed +2f;
        }
        else
        {
            speed = 12f;
        }
        character.Move(move * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (!playerFX.isPlaying)
            {
                playerFX.PlayOneShot(footSteps);
            }
        }
        else
        {
            playerFX.Stop();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        character.Move(velocity * Time.deltaTime);

        if (inputEnabled == true)
        {
            transform.Translate(Vector3.right * 5 * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
            transform.Translate(Vector3.up * 5 * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        }

    }

    void Activate()
    {
        inputEnabled = true;
    }

    void Deactivate()
    {
        inputEnabled = true;
    }
}
