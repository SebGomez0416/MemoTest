using System.IO;
using UnityEngine;

public class HighScoreData : MonoBehaviour
{
    private const string path = "Assets/Art/Data/HighScore.dat";

    private struct highScore 
    { 
      public string name; 
      public int turns;
    }
    private highScore[] HighScores;
    
    private void Start()
    {
        HighScores = new highScore[3];
        LoadHigScore();
    }

    private void OnEnable()
    {
        UI.ChangeHighScore += OnCompareTurns;
    }

    private void OnDisable()
    {
        UI.ChangeHighScore -= OnCompareTurns;
    }

    private void LoadHigScore()
    {
        if (!File.Exists(path)) return;
        FileStream fs = File.OpenRead(path);
        BinaryReader br = new BinaryReader(fs);

        for (int i = 0; i < HighScores.Length; i++)
        {
            HighScores[i].name = br.ReadString();
            HighScores[i].turns = br.ReadInt32();
        }
        
        br.Close();
        fs.Close();
    }

    private void OnCompareTurns(string name, int t)
    {
        for (int i = 0; i < HighScores.Length; i++)
        {
            if (t <  HighScores[i].turns)
            {
                string auxName = HighScores[i].name;
                int auxScore = HighScores[i].turns;
                
                HighScores[i].turns = t;
                HighScores[i].name = name;

                t = auxScore;
                name = auxName;
            }
        }
        SaveHigScore();
    }
   
    
    private void SaveHigScore()
    {
        FileStream fs = File.OpenWrite(path);
        BinaryWriter bw = new BinaryWriter(fs);

        for (int i = 0; i < HighScores.Length; i++)
        {
            bw.Write(HighScores[i].name);
            bw.Write(HighScores[i].turns);
        }

        bw.Close();
        fs.Close();
    }
    
    


}
