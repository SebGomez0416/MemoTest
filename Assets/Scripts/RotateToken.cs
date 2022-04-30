using UnityEngine;

public class RotateToken : MonoBehaviour
{
    [SerializeField] private Vector3 rotateFront;
    private TokenData t;
    private bool isMatch;
    public delegate void SendToken(TokenData t);
    public static SendToken OnSendToken;

    private void Awake()
    {
        t = GetComponentInChildren<TokenData>();
    }
    private void OnEnable()
    {
        TokenManager.OnResetToken += ResetToken;
    }
    private void OnDisable()
    {
        TokenManager.OnResetToken -= ResetToken;
    }
    private void OnMouseDown()
    {
        if (isMatch) return;
        Rotate(rotateFront);
        OnSendToken?.Invoke(t);
        isMatch = true;
    }

    private void ResetToken()
    {
        isMatch = false;
    }
    public void Rotate(Vector3 dir)
    {
        transform.rotation = Quaternion.Euler(dir);
    }
}
