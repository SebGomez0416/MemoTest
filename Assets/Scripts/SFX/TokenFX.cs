using UnityEngine;

public class TokenFX : MonoBehaviour
{
    private AudioSource _audioSource;
        
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void OnEnable()
    {
        RotateToken.SelectToken += OnSelectToken;
    }

    private void OnDisable()
    {
        RotateToken.SelectToken -= OnSelectToken;
    }

    private void OnSelectToken()
    {
        _audioSource.Play();
    }
}
