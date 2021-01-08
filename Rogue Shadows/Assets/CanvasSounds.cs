using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSounds : MonoBehaviour
{
    AudioSource CanvasFX;
    [SerializeField] AudioClip theme;
    void Start()
    {
        CanvasFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanvasFX.isPlaying)
        {
            CanvasFX.PlayOneShot(theme);
        }
    }
}
