using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject GameOverMenu;
    public GameObject PauseMenu;
    public GameObject StartMenu;
    public GameObject GameMenu;

    public GameObject Spawner;

    [Header("Bools")]
    public bool isPaused;
    public bool isStarted;
    [HideInInspector] public bool isDead;

    public int score;

    [SerializeField] TMP_Text scoreText;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
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
