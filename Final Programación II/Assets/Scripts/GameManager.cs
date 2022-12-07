using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;

    private float score;
    private float highScore;

    private float timer;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        score = 0f;
        UpdateHighScore();
        Time.timeScale = 1f;
    }
    private void Update()
    {
        UpdateScore();
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        UpdateHighScore();

    }

    void UpdateScore()
    {
        score = timer += Time.deltaTime;
        scoreText.text = Mathf.RoundToInt(score).ToString("D5");
    }

    void UpdateHighScore()
    {
        highScore = PlayerPrefs.GetFloat("highscore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highscore", highScore);
        }

        highScoreText.text = Mathf.RoundToInt(highScore).ToString("D5");
    }
}
