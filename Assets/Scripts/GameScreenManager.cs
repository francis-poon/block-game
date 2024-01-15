using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScreenManager : MonoBehaviour
{
    [Header("In Game Elements")]
    [SerializeField]
    private GameObject levelDisplay;
    [SerializeField]
    private GameObject levelText;
    [SerializeField]
    private GameObject scoreText;
    

    [Header("Cleared Level Elements")]
    [SerializeField]
    private GameObject clearedLevelDisplay;
    [SerializeField]
    private GameObject clearedScoreText;
    [SerializeField]
    private GameObject clearedDisplayTitle;
    [SerializeField]
    private GameObject nextLevelButton;

    public bool updateScore;
    public GameState lastState;

    private void Awake()
    {
        GameManager.onAfterStateChanged += OnStateChanged;
        updateScore = false;
    }

    private void OnDestroy()
    {
        GameManager.onAfterStateChanged -= OnStateChanged;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (!updateScore)
        {
            return;
        }

        scoreText.GetComponent<TextMeshProUGUI>().text = $"{GameManager.instance.score}";
    }

    private void OnStateChanged(GameState newState)
    {
        Debug.Log($"Game Screen received {newState}");
        lastState = newState;
        switch (newState)
        {
            case GameState.Playing:
                Debug.Log("Game Screen received playing state");
                levelDisplay.SetActive(true);
                clearedLevelDisplay.SetActive(false);
                levelText.GetComponent<TextMeshProUGUI>().text = $"Level {GameManager.instance.currentLevel + 1}";
                updateScore = true;
                break;
            case GameState.ClearedLevel:
                clearedDisplayTitle.GetComponent<TextMeshProUGUI>().text = GameManager.instance.HasNextLevel() ? "CLEARED" : "COMPLETE";
                clearedScoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {GameManager.instance.score}";
                levelDisplay.SetActive(false);
                clearedLevelDisplay.SetActive(true);
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

    public void Retry()
    {
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
}
