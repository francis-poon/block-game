using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject levelSelectButton;

    [Header("Attributes")]
    [SerializeField]
    private GameObject levelSelectGrid;

    [Header("Unlockable Display")]
    [SerializeField]
    private GameObject unlockableDisplay;
    [SerializeField]
    private float fadeOutStagger;
    [SerializeField]
    private float fadeOutDelay;
    [SerializeField]
    private float fadeOutTime;
    [SerializeField]
    private float delayBeforeFadeIn;
    [SerializeField]
    private float fadeInStagger;
    [SerializeField]
    private float fadeInDelay;
    [SerializeField]
    private float fadeInTime;

    private GameObject[] levelSelectButtons;
    private GameObject[] unlockables;

    private void Awake()
    {
        levelSelectButtons = new GameObject[GameData.levels.GetLength(0)];
        unlockables = new GameObject[GameData.levels.GetLength(0)];
    }

    private void Start()
    {
        for (int c = 0; c < GameData.levels.GetLength(0); c++)
        {
            levelSelectButtons[c] = Instantiate(levelSelectButton, levelSelectGrid.transform);
            levelSelectButtons[c].GetComponentInChildren<TextMeshProUGUI>().text = $"{c + 1}";
            int levelIndex = c;
            levelSelectButtons[c].GetComponent<Button>().onClick.AddListener(() => SelectLevel(levelIndex));
            levelSelectButtons[c].GetComponent<Button>().onClick.AddListener(StartGame);
            levelSelectButtons[c].GetComponent<Button>().interactable = c <= GameData.unlockedLevel;
            unlockables[c] = new GameObject();
            unlockables[c].transform.SetParent(unlockableDisplay.transform);
            unlockables[c].transform.localEulerAngles = Vector3.zero;
            unlockables[c].transform.localScale = Vector3.one;
            unlockables[c].transform.localPosition = Vector3.zero;
            unlockables[c].AddComponent<SpriteRenderer>();
            unlockables[c].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(GameData.rewards[c]);
            unlockables[c].GetComponent<SpriteRenderer>().sortingOrder = 1;
            unlockables[c].SetActive(c + 1 <= GameData.unlockedLevel);
        }
        
    }

    public void SelectLevel(int level)
    {
        Debug.Log($"Selecting level {level}");
        GameData.selectedLevel = level;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void AnimatePieces()
    {
        StartCoroutine(FadePiecesIn());
    }

    private IEnumerator FadePiecesOut()
    {
        for (int c = 0; c < GameData.unlockedLevel; c++)
        {
            if (fadeOutStagger > 0)
            {
                yield return new WaitForSeconds(fadeOutStagger);
            }
            if (c + 1 == GameData.unlockedLevel)
            {
                yield return StartCoroutine(GameObjectUtils.FadeOut(unlockables[c].GetComponent<SpriteRenderer>(), fadeOutDelay, fadeOutTime));
            }
            else
            {
                StartCoroutine(GameObjectUtils.FadeOut(unlockables[c].GetComponent<SpriteRenderer>(), fadeOutDelay, fadeOutTime));
            }
        }
        yield return null;
    }

    private IEnumerator FadePiecesIn()
    {
        yield return FadePiecesOut();

        for (int c = 0; c < GameData.unlockedLevel; c++)
        {
            if (fadeInStagger > 0)
            {
                yield return new WaitForSeconds(fadeInStagger);
            }
            StartCoroutine(GameObjectUtils.FadeIn(unlockables[c].GetComponent<SpriteRenderer>(), fadeInDelay, fadeInTime));
        }
    }
}
