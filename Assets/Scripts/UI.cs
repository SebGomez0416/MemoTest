using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private Text textClock;
    [SerializeField] private Text textTry;
    [SerializeField] private GameObject match;
    [SerializeField] private GameObject gameOver;

    private int _match;
    private int tokensMatch = 10;
    private int turns;
    private bool timerBool;
    private float currentTime;
    private TimeSpan timer;

    private void Awake()
    {
        textClock.text = "00:00";
        textTry.text = " "+ turns;
        timerBool = false;
    }
    private void Start()
    {
        InitTimer();
    }

    private void OnEnable()
    {
        TokenManager.SendTry += OnSendTry;
        TokenManager.SendMatch += OnSendMatch;
    }

    private void OnDisable()
    {
        TokenManager.SendTry -= OnSendTry;
        TokenManager.SendMatch -= OnSendMatch;
    }
    
    private void OnSendMatch()
    {
        _match++;
        GameOver();
        match.SetActive(true);
        Invoke("SetMatch",1f);
    }

    private void SetMatch()
    {
        match.SetActive(false);
    }

    private void OnSendTry()
    {
        turns ++;
        textTry.text = " "+ turns;
    }

    private void InitTimer()
    {
        timerBool = true;
        currentTime = 0;
        StartCoroutine("UpdateTime");
    }

    private void EndTime()
    {
        timerBool = false;
    }

    private IEnumerator UpdateTime()
    {
        while (timerBool)
        {
            currentTime += Time.deltaTime;
            timer =TimeSpan.FromSeconds(currentTime);
            string timerStr =" "+ timer.ToString("mm':'ss");
            textClock.text = timerStr;
            yield return null;
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ChangScene()
    {
        SceneManager.LoadScene("Menu");
    }

    private void GameOver()
    {
        if (_match != tokensMatch) return;
        gameOver.SetActive(true);
        EndTime();
    }

}
