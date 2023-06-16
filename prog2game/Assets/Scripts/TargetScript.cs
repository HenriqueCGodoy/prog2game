using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private int targetValue;
    private AudioSource targetAudioSource;

    private void Start()
    {
        targetAudioSource = GetComponent<AudioSource>();
    }

    public int GetTargetValue()
    {
        return targetValue;
    }

    public void PlayHitSound()
    {
        targetAudioSource.Play();
    }


}
