using UnityEngine;

public class TokenData : MonoBehaviour
{
    [SerializeField]private int _id;
    private MeshRenderer mr;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }
    public void SetMaterial(Material mat)
    {
        mr.material = mat;
    }
    public Material GetMaterial()
    {
        return  mr.material;
    }
}
