using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private Text textClock;
    [SerializeField] private Text textTry;
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
    }

    private void OnDisable()
    {
        TokenManager.SendTry -= OnSendTry;
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

}
