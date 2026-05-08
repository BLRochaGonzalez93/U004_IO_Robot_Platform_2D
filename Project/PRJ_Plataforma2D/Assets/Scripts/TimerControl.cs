using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public Image timeBar;
    public TextMeshProUGUI timeText;
    public int maxTime;
    static public float timer;
    public bool isTimerOn;
    static public string finishTime;

    private void Start()
    {
        maxTime = 60;
        timer = maxTime;
        isTimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime/2;
        if (timer >= 0)
        {
            timeBar.fillAmount = timer / maxTime;
            timeText.text = "Time Left: " + Mathf.Round(timer) + " secs";
            finishTime = timer.ToString();
        }
        else
        {
            isTimerOn = false;
            SceneManager.LoadScene(4);
        }
    }

    static public string getTime()
    {
        return finishTime;
    }

    static public int getFloatTime()
    {
        return Mathf.RoundToInt(timer)/2;
    }
}
