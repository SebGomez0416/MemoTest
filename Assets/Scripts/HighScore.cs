using System.IO;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private const string path = "Assets/Art/Data/HighScore";


    private void SaveHigScore()
    {
        FileStream fs = File.OpenWrite(path);
        BinaryWriter bw = new BinaryWriter(fs);

       // bw.Write();
        

        bw.Close();
        fs.Close();
    }
    private void LoadHigScore()
    {
        if (!File.Exists(path)) return;
        FileStream fs = File.OpenRead(path);
        BinaryReader br = new BinaryReader(fs);
        
        
        br.Close();
        fs.Close();
    }


}
