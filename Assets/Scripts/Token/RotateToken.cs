using System;
using UnityEngine;

public class RotateToken : MonoBehaviour
{
    [SerializeField] private Vector3 rotateFront;
    private TokenData t;
    [SerializeField] private bool isMatch;
    private bool isBlock;
    public static event Action <TokenData > SendToken;
    public static event Action  SelectToken;
    private void Awake()
    {
        t = GetComponentInChildren<TokenData>();
    }

    private void OnEnable()
    {
        TokenManager.BlockTokens += OnBlockTokens;
    }

    private void OnDisable()
    {
        TokenManager.BlockTokens-=OnBlockTokens;
    }

    private void OnBlockTokens()
    {
        isBlock = !isBlock;
    }

    private void OnMouseDown()
    {
        if (isBlock||isMatch) return;
        Rotate(rotateFront);
        SendToken?.Invoke(t);
        SelectToken?.Invoke();
        isMatch = true;
    }
    public void ResetToken()
    {
        isMatch = false;
    }
    
    public void Rotate(Vector3 dir)
    {
        transform.rotation = Quaternion.Euler(dir);
    }
}
