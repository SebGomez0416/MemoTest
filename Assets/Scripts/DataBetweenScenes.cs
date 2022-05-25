using UnityEngine;

public class DataBetweenScenes : MonoBehaviour
{
    public static DataBetweenScenes instance;
    public string _name;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
