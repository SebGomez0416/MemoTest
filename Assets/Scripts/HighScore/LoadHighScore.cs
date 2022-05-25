using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighScore : MonoBehaviour
{
   private const string path = "Assets/Art/Data/HighScore.dat";
   [SerializeField] private Text highScore_one;
   [SerializeField] private Text highScore_two;
   [SerializeField] private Text highScore_three;

   private void Start()
   {
       LoadHigScore();
   }

   private void LoadHigScore()
    {
        if (!File.Exists(path)) return;
        FileStream fs = File.OpenRead(path);
        BinaryReader br = new BinaryReader(fs);
        
        WriteScore(br.ReadString(),br.ReadInt32(),highScore_one);
        WriteScore(br.ReadString(),br.ReadInt32(),highScore_two);
        WriteScore(br.ReadString(),br.ReadInt32(),highScore_three);
        

        br.Close();
        fs.Close();
    }

   private void WriteScore(string name, int score, Text field)
   {
       field.text += " " + name + "                 " + score;
   }
}
