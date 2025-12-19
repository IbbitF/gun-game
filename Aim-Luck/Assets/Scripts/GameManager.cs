using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public int score = 0; // Player's score
    public bool isGameActive = true; // Is the game running?
    public int level = 1;
    public int goal = 0;
    public int currentLevel = 0;
    public float time = 0f;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        SetScoreText();
    }

    void Awake()
    {
        // Ensure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void AddScore(int points)
    {
        if (isGameActive)
        {
            score += points;
            Debug.Log("Score: " + score);
            SetScoreText();
        }
    }

    void SetLevel(int newLevel)
    {
        level = newLevel;

        if (level == 1)
        {
            goal = 10;
            time = 20f;
        }
        else if (level == 2)
        {
            goal = 15;
            time = 30f;
        }
        else if (level == 3)
        {
            goal = 20;
            time = 40f;
        }

        score = 0;
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
