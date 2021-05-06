using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip shootClip;
    public AudioClip sheepHitClip;
    public AudioClip sheepDroppedClip;

    private Vector3 cameraPosition;

    private void PlaySound(AudioClip clip)
    {
        // Create a temporary AudioSource that plays the audio passed as a parameter at the location of the camera
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }

    // Awake is called first before start
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        
    }
}
