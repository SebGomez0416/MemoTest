using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject screenCredits;
    [SerializeField] private GameObject screenName;
    [SerializeField] private GameObject screenHighScore;

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void ButtonPlay(bool set)
    {
        screenName.SetActive(set);
    }
    public void ButtonHighScore(bool set)
    {
        screenHighScore.SetActive(set);
    }

    public void ButtonCredits(bool set)
    {
        screenCredits.SetActive(set);
    }
    
    public void ButtonExit()
    {
        Application.Quit();
    }
    
    
}
