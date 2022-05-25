using System;
using System.IO;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private const string path = "Assets/Art/Data/HighScore.dat";

    private void SaveHigScore()
    {
        FileStream fs = File.OpenWrite(path);
        BinaryWriter bw = new BinaryWriter(fs);

        string name = "sergio";
        string name1 = "oscar";
        string name2 = "amina";

        int score =33;
        int score1 =38;
        int score2 =42;
        
        bw.Write(name);
        bw.Write(score);
        
        bw.Write(name1);
        bw.Write(score1);
        
        bw.Write(name2);
        bw.Write(score2);
        

        bw.Close();
        fs.Close();
    }
    


}
