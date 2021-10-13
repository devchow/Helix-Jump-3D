using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("States | Booleans")]
    public static bool gameOver;
    public static bool levelComplete;
    public static bool mute = false;
    public static bool isGameStarted;

    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    [Header("UI")]
    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public Text currentLevelText;
    public Text nextLevelText;

    public static int ringsPassed;
    public static int score = 0;
    public Text scoreTxt;
    public Text highScoreTxt;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    void Start()
    {
        Time.timeScale = 1;
        ringsPassed = 0;
        highScoreTxt.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);

        // When Game Starts its not over yet
        gameOver = levelComplete = false;
        isGameStarted = false;

        // Loading Interstitial Ad
        AdManager.instance.RequestInterstitial();
    }

    void Update()
    {
        // Update the UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        // Game Progress
        int progress = ringsPassed * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        // Displaying Score
        scoreTxt.text = score.ToString();

        // Enabling GamePlay Panel  | Hiding Start-Menu Panel
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }

        // If Game is Over
        if (gameOver)
        {
            // Pausing the Game
            Time.timeScale = 0;

            // Interstitial Ad | to display after a while
            if(Random.Range(0, 3) == 1)
            {
                AdManager.instance.ShowInterstitial();
            }

            // Displaying Game Over Panel
            gameOverPanel.SetActive(true);

            // Reload Scene when player press Restart
            if (Input.GetButtonDown("Fire1"))
            {
                // Updating High Score
                if(score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);

                    // Adding Score to leader-Board
                    FindObjectOfType<PlayGames>().AddScoreToLeaderboard();
                }

                score = 0;
                SceneManager.LoadScene("Level");
            }
        }

        // If Level is Complete
        if (levelComplete)
        {
            // Pausing the Game
            Time.timeScale = 0; 

            // Displaying Level Complete Panel
            levelCompletePanel.SetActive(true);

            // Reload Scene when player press Restart
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);

                SceneManager.LoadScene("Level");
            }
        }
    }
}
