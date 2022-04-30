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
    public void SetId(int id)
    {
        _id = id;
    }

    public int GetId()
    {
        return _id;
    }
    public Material GetMaterial()
    {
        return  mr.material;
    }
}
