using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


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
    private TokenData tokenOne;
    private TokenData tokenTwo;
    private int id;
    public delegate void ResetToken();
    public static ResetToken OnResetToken;
    [SerializeField] private Vector3 rotateBack;
    private void Start()
    {
        SpawnBoard();
    }

    private void OnEnable()
    {
        RotateToken.OnSendToken +=GetToken;
    }

    private void OnDisable()
    {
        RotateToken.OnSendToken -=GetToken;
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
               token.SetId(SetId());
               tokens.Add(token);

            }
        }
    }
    private int SetId()
    {
        id++;
        return id;
    }
    private Material SetMaterial()
    {
        Material m;
        do
        {
          m = colors[Random.Range(0,colors.Count-1)];
          
        } while (!AddMaterial(m));
        return m;
    }
    private bool AddMaterial(Material m)
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

    private void GetToken(TokenData t)
    {
        if (tokenOne == null)
            tokenOne = t;
        else
        {
            tokenTwo = t;
            TokenMatch();
        }
    }
    
    private void TokenMatch()
    {
        if (tokenOne.GetMaterial().color == tokenTwo.GetMaterial().color)
        {
            Debug.Log("Match");
            tokenOne = null;
            tokenTwo = null;
        }
           
        else Invoke("RestoreToken",0.5f);
    }

    private void RestoreToken()
    {
        //pregruntar 
        foreach (var t in tokens.Where(t => tokenOne.GetId()== t.GetId()||tokenTwo.GetId()== t.GetId()))
        {
            t.GetComponentInParent<RotateToken>().Rotate(rotateBack);
        }
        
        OnResetToken?.Invoke();
        tokenOne = null;
        tokenTwo = null;
    }

    
}