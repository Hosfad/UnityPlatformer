using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public Button playAgainButton; // renamed to next
    public Button menuButton;


    public Text HpText;
    public Text ScoreText;
    void Start()
    {

        if (playAgainButton != null)
        {
            playAgainButton.onClick.AddListener(PlayAgain);
        }

        if (menuButton != null)
        {
            menuButton.onClick.AddListener(Menu);
        }
    }

    void Update()
    {
        HpText.text = GameManager.Instance.playerHp.ToString();
        ScoreText.text = GameManager.Instance.playerScore.ToString();
    }
    public void PlayAgain()
    {
        Time.timeScale = 1;

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex < 2)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            Menu();
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}