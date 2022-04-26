using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToken : MonoBehaviour
{
    [SerializeField] private Vector3 rotate;
    private void OnMouseDown()
    {
        transform.rotation = Quaternion.Euler(rotate);

    }
}
