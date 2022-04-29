using System.Collections.Generic;
using UnityEngine;


public class TokenManager : MonoBehaviour
{
    [SerializeField] private List<Material> colors;
    [SerializeField] private List<TokenData> tokens;
    [SerializeField] private GameObject prefabToken;
    [SerializeField] private int high;
    [SerializeField] private int width;
    [SerializeField] private int offSetX;
    [SerializeField] private int offSetY;
    private Vector3 position;
    private TokenData token;
    private int id;
    private int materialMatch;
    


    private void Start()
    {
        SpawnBoard();
    }
    private void SpawnBoard()
    {
        for (int i = 0; i < high; i++)
        {
            for (int j = 0; j < width; j++)
            {   
                if(j!=0)
                    position.x += prefabToken.transform.localScale.x + offSetX;
                if(i!=0)
                    position.y = (prefabToken.transform.position.y - (offSetY*i)) - (prefabToken.transform.localScale.y *i );
                if (i != 0 && j == 0)
                    position.x = prefabToken.transform.position.x;
               
               GameObject t= Instantiate(prefabToken, position, prefabToken.transform.rotation,transform);
               token = t.GetComponentInChildren<TokenData>();
               token.SetMaterial(SetMaterial());
               tokens.Add(token);

            }
        }
    }

    private Material SetMaterial()
    {
        Material m;
        do
        {
          m = colors[Random.Range(0,colors.Count-1)];
          
        } while (!CheckMaterial(m));
        return m;
    }


    private bool CheckMaterial(Material m)
    {
        int match=0;
        if (tokens.Count != 0)
        { 
            foreach (TokenData t in tokens)
            {
                if ( t.GetMaterial().color == m.color)
                    match++;
            }
        }
        
        if (match > 1) return false;
        if (match == 1) colors.Remove(m);
        return true;
    }
    
    
}
