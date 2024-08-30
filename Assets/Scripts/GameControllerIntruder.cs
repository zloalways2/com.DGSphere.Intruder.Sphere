using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerIntruder : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuIntruder;
    [SerializeField] private GameObject gameMenuIntruder;
    [SerializeField] private GameObject levelMenuIntruder;
    [SerializeField] private GameObject optionsMenuIntruder;
    [SerializeField] private GameObject policyMenuIntruder;
    [SerializeField] private GameObject winMenuIntruder;
    [SerializeField] private GameObject exitMenuIntruder;

    private int pointsCountIntruder;
    [SerializeField] private TextMeshProUGUI pointsTextIntruder;
    [SerializeField] private TimerIntruder timerIntruderIntruder;

    private int isMusicIntruder;
    private int isSoundIntruder;

    [SerializeField] private GameObject soundOffImageIntruder;
    [SerializeField] private GameObject soundOnImageIntruder;
    [SerializeField] private GameObject musicOffImageIntruder;
    [SerializeField] private GameObject musicOnImageIntruder;

    [SerializeField] private Button[] levelsButtonIntruder;
    [SerializeField] private TextMeshProUGUI[] levelsTextIntruder;
    [SerializeField] private Color enableColorIntruder;
    [SerializeField] private Color disableColorIntruder;
    [SerializeField] private AudioSource audioSourceIntruder;
    [SerializeField] private AudioClip clickClipIntruder;
    [SerializeField] private AudioClip backgroundClipIntruder;

    [SerializeField] private TextMeshProUGUI finalHeaderTextIntruder;
    [SerializeField] private TextMeshProUGUI finalButtonTextIntruder;

    [SerializeField] private ColorGame colorGame;
    [SerializeField] private GameObject colorGameObject;

    private bool isOptionsFromGameIntruder;

    private int currentLevelIntruder;
    private int maxLevelIntruder;

    private void Start()
    {
        Application.targetFrameRate = 60;
        maxLevelIntruder = PlayerPrefs.GetInt("maxLevelIntruder", 1);
        UpdateLevelsButtonIntruder();
        mainMenuIntruder.SetActive(true);
        gameMenuIntruder.SetActive(false);
        optionsMenuIntruder.SetActive(false);
        policyMenuIntruder.SetActive(false);
        winMenuIntruder.SetActive(false);
        levelMenuIntruder.SetActive(false);

        isMusicIntruder = PlayerPrefs.GetInt("musicIntruder", 1);
        isSoundIntruder = PlayerPrefs.GetInt("soundIntruder", 1);

        if (isSoundIntruder == 0)
        {
            soundOffImageIntruder.SetActive(true);
            soundOnImageIntruder.SetActive(false);
        }
        else
        {
            soundOffImageIntruder.SetActive(false);
            soundOnImageIntruder.SetActive(true);
        }
        if (isMusicIntruder == 0)
        {
            musicOffImageIntruder.SetActive(true);
            musicOnImageIntruder.SetActive(false);
        }
        else
        {
            audioSourceIntruder.clip = backgroundClipIntruder;
            audioSourceIntruder.Play();
            musicOffImageIntruder.SetActive(false);
            musicOnImageIntruder.SetActive(true);
        }
    }

    public void ShowExitMenuIntruder()
    {
        ClickSoundIntruder();
        timerIntruderIntruder.PauseTimerIntruder();
        Time.timeScale = 0;
        colorGameObject.SetActive(false);
        gameMenuIntruder.SetActive(false);
        exitMenuIntruder.SetActive(true);
    }

    public void CloseExitMenuIntruder()
    {
        ClickSoundIntruder();
        timerIntruderIntruder.ContinueTimerIntruder();
        Time.timeScale = 1;
        colorGameObject.SetActive(true);
        gameMenuIntruder.SetActive(true);
        exitMenuIntruder.SetActive(false);
    }

    public void OnSwitchSoundIntruder()
    {
        if (isSoundIntruder == 0)
        {
            soundOffImageIntruder.SetActive(false);
            soundOnImageIntruder.SetActive(true);
            isSoundIntruder = 1;
            PlayerPrefs.SetInt("soundIntruder", isSoundIntruder);
            PlayerPrefs.Save();
        }
        else
        {
            soundOffImageIntruder.SetActive(true);
            soundOnImageIntruder.SetActive(false);
            isSoundIntruder = 0;
            PlayerPrefs.SetInt("soundIntruder", isSoundIntruder);
            PlayerPrefs.Save();
        }

        var d890 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d890++;
        }
    }

    public void OnSwitchMusicIntruder()
    {
        if (isMusicIntruder == 0)
        {
            musicOffImageIntruder.SetActive(false);
            musicOnImageIntruder.SetActive(true);
            isMusicIntruder = 1;
            PlayerPrefs.SetInt("musicIntruder", isMusicIntruder);
            PlayerPrefs.Save();
            audioSourceIntruder.clip = backgroundClipIntruder;
            audioSourceIntruder.Play();
        }
        else
        {
            musicOffImageIntruder.SetActive(true);
            musicOnImageIntruder.SetActive(false);
            isMusicIntruder = 0;
            PlayerPrefs.SetInt("musicIntruder", isMusicIntruder);
            PlayerPrefs.Save();
            audioSourceIntruder.clip = backgroundClipIntruder;
            audioSourceIntruder.Stop();
        }

        var d795 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d795++;
        }
    }

    public void UpdateLevelsButtonIntruder()
    {
        for (int iIntruder = 0; iIntruder < levelsButtonIntruder.Length; iIntruder++)
        {
            if (iIntruder < maxLevelIntruder)
            {
                levelsButtonIntruder[iIntruder].interactable = true;
                levelsTextIntruder[iIntruder].color = enableColorIntruder;
            }
            else
            {
                levelsButtonIntruder[iIntruder].interactable = false;
                levelsTextIntruder[iIntruder].color = disableColorIntruder;
            }
        }
    }

    public void UpdatePointsIntruder(int x)
    {
        if (timerIntruderIntruder.GetTimerStatusIntruder())
        {
            pointsCountIntruder += x;
            pointsTextIntruder.text = $"Score: {pointsCountIntruder}/{250 + 10 * currentLevelIntruder}";
            if (pointsCountIntruder >= (250 + 10 * currentLevelIntruder))
            {
                timerIntruderIntruder.PauseTimerIntruder();
                ShowWinMenuIntruder();
            }
        }
    }

    public void ShowGameMenuIntruder(int num)
    {
        ClickSoundIntruder();
        currentLevelIntruder = num;
        levelMenuIntruder.SetActive(false);
        mainMenuIntruder.SetActive(false);
        pointsCountIntruder = 0;
        pointsTextIntruder.gameObject.SetActive(true);
        pointsTextIntruder.text = $"Score: {pointsCountIntruder}/{250 + 10 * currentLevelIntruder}";
        timerIntruderIntruder.gameObject.SetActive(true);
        timerIntruderIntruder.RestartTimerIntruder();
        levelMenuIntruder.SetActive(false);
        gameMenuIntruder.SetActive(true);
        colorGame.Restart();
        colorGameObject.SetActive(true);
    }

    public void FromMainMenuToLevelMenuIntruder()
    {
        ClickSoundIntruder();
        var d123 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d123++;
        }
        mainMenuIntruder.SetActive(false);

        for (int jyt = 0; jyt < 5; jyt++)
        {
            d123++;
        }
        levelMenuIntruder.SetActive(true);
    }

    public void FromLevelMenuToMainMenuIntruder()
    {
        ClickSoundIntruder();
        var d111 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d111++;
        }
        levelMenuIntruder.SetActive(false);
        for (int jyt = 0; jyt < 5; jyt++)
        {
            d111++;
        }

        mainMenuIntruder.SetActive(true);
    }

    public void FromGameToLevelMenuIntruder()
    {
        ClickSoundIntruder();
        gameMenuIntruder.SetActive(false);
        timerIntruderIntruder.PauseTimerIntruder();
        winMenuIntruder.SetActive(false);
        levelMenuIntruder.SetActive(true);
        exitMenuIntruder.SetActive(false);
    }

    public void FromGameToMainMenuIntruder()
    {
        ClickSoundIntruder();
        gameMenuIntruder.SetActive(false);
        timerIntruderIntruder.PauseTimerIntruder();
        winMenuIntruder.SetActive(false);
        mainMenuIntruder.SetActive(true);
    }

    public void ShowWinMenuIntruder()
    {
        colorGameObject.SetActive(false);
        gameMenuIntruder.SetActive(false);
        winMenuIntruder.SetActive(true);
        if (pointsCountIntruder >= (250 + 10 * currentLevelIntruder))
        {
            finalHeaderTextIntruder.text = "You win";
            finalButtonTextIntruder.text = "Next level!";
            if (maxLevelIntruder == currentLevelIntruder)
            {
                maxLevelIntruder++;
                PlayerPrefs.SetInt("maxLevelIntruder", maxLevelIntruder);
                PlayerPrefs.Save();
                UpdateLevelsButtonIntruder();
            }
        }
        else
        {
            finalHeaderTextIntruder.text = "You lose";
            finalButtonTextIntruder.text = "Retry";
        }
    }

    public void AppExitIntruder()
    {
        ClickSoundIntruder();
        var d444 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d444++;
        }

        for (int jyt = 0; jyt < 5; jyt++)
        {
            d444++;
        }
        Application.Quit();
    }

    private void ClickSoundIntruder()
    {
        var d555 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d555++;
        }

        if (isSoundIntruder == 1)
        {
            audioSourceIntruder.PlayOneShot(clickClipIntruder, 1f);
        }
    }

    public void FromMainMenuToOptionsMenuIntruder()
    {
        ClickSoundIntruder();

        var d678 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d678++;
        }
        mainMenuIntruder.SetActive(false);

        for (int jyt = 0; jyt < 5; jyt++)
        {
            d678++;
        }

        optionsMenuIntruder.SetActive(true);
    }

    public void FromOptionsMenuToMainMenuIntruder()
    {
        ClickSoundIntruder();
        optionsMenuIntruder.SetActive(false);
        if (isOptionsFromGameIntruder)
        {
            colorGameObject.SetActive(true);
            isOptionsFromGameIntruder = false;
            timerIntruderIntruder.ContinueTimerIntruder();
            Time.timeScale = 1;
            gameMenuIntruder.SetActive(true);
        }
        else
        {
            mainMenuIntruder.SetActive(true);
        }
    }

    public void ShowPolicyMenuIntruder()
    {
        ClickSoundIntruder();
        var d444 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d444++;
        }
        mainMenuIntruder.SetActive(false);

        for (int jyt = 0; jyt < 5; jyt++)
        {
            d444++;
        }

        policyMenuIntruder.SetActive(true);
    }

    public void ClosePolicyMenuIntruder()
    {
        ClickSoundIntruder();
        var d552 = 0;
        for (int fgh = 0; fgh < 78; fgh++)
        {
            d552++;
        }
        policyMenuIntruder.SetActive(false);

        for (int jyt = 0; jyt < 5; jyt++)
        {
            d552++;
        }
        mainMenuIntruder.SetActive(true);
    }

    public void ShowOptionsMenuFromGameIntruder()
    {
        ClickSoundIntruder();
        colorGameObject.SetActive(false);
        isOptionsFromGameIntruder = true;
        Time.timeScale = 0;
        timerIntruderIntruder.PauseTimerIntruder();
        gameMenuIntruder.SetActive(false);
        optionsMenuIntruder.SetActive(true);
    }
}