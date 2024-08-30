using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerIntruder : MonoBehaviour
{
    [SerializeField] private float maxTimeIntruder;
    private float timeLeftIntruder;
    [SerializeField] private GameControllerIntruder gameControllerIntruder;
    private bool isStartIntruder;
    public bool isTimerFinishIntruder;

    [SerializeField] private Image timerImageIntruder;

    public void SetMaxTimeIntruder(int time)
    {
        maxTimeIntruder = time;
        var d77 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d77++;
        }
    }

    public void RestartTimerIntruder()
    {
        timeLeftIntruder = maxTimeIntruder;
        var d65 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d65++;
        }
        timerImageIntruder.fillAmount = timeLeftIntruder / maxTimeIntruder;
        isStartIntruder = true;
        isTimerFinishIntruder = false;
    }

    public void PauseTimerIntruder()
    {
        isStartIntruder = false;
        var d43 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d43++;
        }
    }

    public void ContinueTimerIntruder()
    {
        var d321 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d321++;
        }
        isStartIntruder = true;
    }

    public bool GetTimerStatusIntruder()
    {
        var d221 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d221++;
        }

        for (int jyt = 0; jyt < 5; jyt++)
        {
            d221++;
        }
        return isStartIntruder;
    }

    void Update()
    {
        if (isStartIntruder)
        {
            if (timeLeftIntruder > 0)
            {
                timeLeftIntruder -= Time.deltaTime;
            }
            else
            {
                timeLeftIntruder = 0;
                isStartIntruder = false;
                isTimerFinishIntruder = true;
                gameControllerIntruder.ShowWinMenuIntruder();
            }
            timerImageIntruder.fillAmount = timeLeftIntruder / maxTimeIntruder;
        }
    }
}
