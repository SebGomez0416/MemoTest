using System;
using UnityEngine;

public class RotateToken : MonoBehaviour
{
    [SerializeField] private Vector3 rotateFront;
    private TokenData t;
    private bool isMatch;
    public static event Action <TokenData > SendToken;

    private void Awake()
    {
        t = GetComponentInChildren<TokenData>();
    }
    private void OnEnable()
    {
        TokenManager.ResetToken += OnResetToken;
    }
    private void OnDisable()
    {
        TokenManager.ResetToken -= OnResetToken;
    }
    private void OnMouseDown()
    {
        if (isMatch) return;
        Rotate(rotateFront);
        SendToken?.Invoke(t);
        isMatch = true;
    }

    private void OnResetToken()
    {
        isMatch = false;
    }
    public void Rotate(Vector3 dir)
    {
        transform.rotation = Quaternion.Euler(dir);
    }
}
