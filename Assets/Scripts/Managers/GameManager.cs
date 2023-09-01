using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject GameMenu;

    public GameObject Spawner;

    //[Header("Bools")]
    public bool isPaused  { get; private set; }
    public bool isStarted { get; private set; }
    [HideInInspector] public bool isDead;

    [HideInInspector] public int score;
    private int highScore;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] TMP_Text highScoreText;

    private void Start()
    {
        Cursor.visible = false;

        StartMenu.SetActive(true);

    }

    private void Update()
    {
        if (Input.anyKey)
        {
            isStarted = true;
            StartMenu.SetActive(false);
            GameMenu.SetActive(true);
            Spawner.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void AddScore(int add)
    {
        score += add;
        scoreText.text = score.ToString();
    }

    public void Retry()
    {
        Debug.Log("Retry");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        finalScoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
        }
        highScoreText.text = highScore.ToString();

        isDead = true;
        Time.timeScale = 0.0f;
        GameOverMenu.SetActive(true);
        GameMenu.SetActive(false);
        Cursor.visible = true;
        Spawner.SetActive(false);
    }

    public void Pause()
    {
        if (isPaused && !isDead)
        {
            isPaused = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (!isPaused && !isDead)
        {
            isPaused = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
       
    }
    
}
