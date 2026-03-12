
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int playerHp = 3;
    public int playerScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}