using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadCredits : MonoBehaviour
{
    private Text credits;

    private void Awake()
    {
        credits = GetComponentInChildren<Text>();
        LoadText();
    }

    private void LoadText()
    {
        FileStream fs = File.OpenRead("Assets/Art/Data/Credits.txt");
        StreamReader sr = new StreamReader(fs);
        credits.text = sr.ReadToEnd();   

        sr.Close();
        fs.Close();        
    }
}
