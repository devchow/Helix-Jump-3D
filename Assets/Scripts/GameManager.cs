using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("States | Game Over & Level Complete")]
    public static bool gameOver;
    public static bool levelComplete;

    [Header("Panels | Game Over & Level Complete")]
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public Text currentLevelText;
    public Text nextLevelText;

    public static int ringsPassed;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    void Start()
    {
        Time.timeScale = 1;
        ringsPassed = 0;
        // When Game Starts its not over yet
        gameOver = false;
        levelComplete = false;
    }

    void Update()
    {
        // Update the UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        // Game Progress
        int progress = ringsPassed * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        // If Game is Over
        if (gameOver)
        {
            // Pausing the Game
            Time.timeScale = 0; 

            // Displaying Game Over Panel
            gameOverPanel.SetActive(true);

            // Reload Scene when player press Restart
            if(Input.GetButtonDown("Fire1"))
            {
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
