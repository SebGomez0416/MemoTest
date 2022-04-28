using UnityEngine;

public class TokenData : MonoBehaviour
{
    [SerializeField]private int _id;
    private MeshRenderer mr;
    private Material _mat;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }
    
    public void SetId(int id)
    {
        _id = id;
    }
    public void SetMaterial(Material mat)
    {
        _mat = mat;
    }

    public int GetId()
    {
        return _id;
    }
    
    public Material GetMaterial()
    {
        return _mat;
    }
}
