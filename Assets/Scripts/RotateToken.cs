using System;
using UnityEngine;

public class RotateToken : MonoBehaviour
{
    [SerializeField] private Vector3 rotateFront;
    private TokenData t;
    [SerializeField] private bool isMatch;
    public static event Action <TokenData > SendToken;
    
    private void Awake()
    {
        t = GetComponentInChildren<TokenData>();
    }
    private void OnMouseDown()
    {
        if (isMatch) return;
        Rotate(rotateFront);
        SendToken?.Invoke(t); 
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
