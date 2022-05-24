using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject screenCredits;

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Gameplay");
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