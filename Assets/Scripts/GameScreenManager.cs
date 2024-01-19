using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScreenManager : MonoBehaviour
{
    [Header("In Game Display")]
    [SerializeField]
    private GameObject levelDisplay;
    [SerializeField]
    private GameObject levelText;
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    private GameObject bestScoreText;
    

    [Header("Cleared Level Display")]
    [SerializeField]
    private GameObject clearedLevelDisplay;
    [SerializeField]
    private GameObject clearedScoreText;
    [SerializeField]
    private GameObject clearedDisplayTitle;
    [SerializeField]
    private GameObject nextLevelButton;

    [Header("Paused Display")]
    [SerializeField]
    private GameObject pausedDisplay;

    private bool updateScore;
    private bool paused;

    private void Awake()
    {
        GameManager.onAfterStateChanged += OnStateChanged;
        updateScore = false;
        paused = false;
    }

    private void OnDestroy()
    {
        GameManager.onAfterStateChanged -= OnStateChanged;
    }
    private void Start()
    {
        bestScoreText.GetComponent<TextMeshProUGUI>().text = $"{GameData.levels[GameManager.instance.currentLevel].bestScore}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (GameManager.instance.state == GameState.Playing || GameManager.instance.state == GameState.Paused))
        {
            paused = !paused;
            if (paused)
            {
                GameManager.instance.ChangeState(GameState.Paused);
            }
            else
            {
                GameManager.instance.ChangeState(GameState.Playing);
            }
        }

        if (updateScore)
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = $"{GameManager.instance.score}";
        }
    }

    private void OnStateChanged(GameState newState)
    {
        updateScore = false;
        switch (newState)
        {
            case GameState.Playing:
                Debug.Log("Game Screen received playing state");
                levelDisplay.SetActive(true);
                clearedLevelDisplay.SetActive(false);
                pausedDisplay.SetActive(false);
                levelText.GetComponent<TextMeshProUGUI>().text = $"Level {GameManager.instance.currentLevel + 1}";
                updateScore = true;
                bestScoreText.GetComponent<TextMeshProUGUI>().text = $"{GameData.levels[GameManager.instance.currentLevel].bestScore}";
                break;
            case GameState.Paused:
                levelDisplay.SetActive(true);
                clearedLevelDisplay.SetActive(false);
                pausedDisplay.SetActive(true);
                break;
            case GameState.ClearedLevel:
                clearedDisplayTitle.GetComponent<TextMeshProUGUI>().text = GameManager.instance.HasNextLevel() ? "CLEARED" : "COMPLETE";
                clearedScoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {GameManager.instance.score}";
                levelDisplay.SetActive(false);
                clearedLevelDisplay.SetActive(true);
                pausedDisplay.SetActive(false);
                nextLevelButton.GetComponent<Button>().interactable = GameManager.instance.HasNextLevel();
                break;
        }
    }

    //===========================================================================================
    //===== BUTTON FUNCTIONS ====================================================================
    //===========================================================================================

    public void GoToNextLevel()
    {
        GameManager.instance.LoadLevel();
    }

    public void ResetLevel()
    {
        paused = false;
        GameManager.instance.LoadLevel();
    }

    public void Retry()
    {
        paused = false;
        GameManager.instance.ResetLevel();
    }

    public void GoToLevelSelect()
    {
        GameData.homeScreenDisplay = "levelSelect";
        SceneManager.LoadScene("HomeScene");
    }

    public void GoHome()
    {
        GameData.homeScreenDisplay = "home";
        SceneManager.LoadScene("HomeScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        paused = false;
        GameManager.instance.ChangeState(GameState.Playing);
    }
}
