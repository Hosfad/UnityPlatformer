using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    public Text HpText;
    public Text ScoreText;

    public GameObject winCanvas;
    public Text finalTimeText;
    private bool isWinning = false;


    void Start()
    {
        startTime = Time.time;
        GameManager.Instance.playerHp = 3;
        GameManager.Instance.playerScore = 0;
    }

    void Update()
    {
        if (isWinning) return;

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString("D2");
        string decimals = ((int)(t * 100) % 100).ToString("D2");

        timerText.text = minutes + ":" + seconds + "." + decimals;

        HpText.text = GameManager.Instance.playerHp.ToString();
        ScoreText.text = GameManager.Instance.playerScore.ToString();

    }

    public void Win()
    {
        if (finalTimeText != null)
        {
            finalTimeText.text = timerText.text;
        }

        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }

        isWinning = true;
        timerText.text = "";
    }
    public void Reset()
    {
        startTime = Time.time;
        timerText.text = "";
    }
}
