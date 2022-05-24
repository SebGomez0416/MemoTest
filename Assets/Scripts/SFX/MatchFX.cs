using System;
using UnityEngine;

public class MatchFX : MonoBehaviour
{
    private AudioSource _audioSource;
        
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        TokenManager.SendMatch += OnMatch;
    }

    private void OnDisable()
    {
        TokenManager.SendMatch -= OnMatch;
    }

    private void OnMatch()
    {
        _audioSource.Play();
    }
}
