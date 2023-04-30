using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerScore;
    [SerializeField] public Text scoreText;
    [SerializeField] public Text levelText;
    public int level;
    public GameObject pauseScreen;
    public bool paused = false;
    public GameObject gameOverScreen;
    public bool gameIsOver = false;
    public bool inSettings = false;
    public GameObject nextLevelScreen;
    public KeyCode pauseKey;
    public Text numArrowsText;
    public Text nameText;
    public GameObject warningText;
    void Start()
    {
        pauseKey = (KeyCode) PlayerPrefs.GetInt("pauseKey", (int) KeyCode.P);
        scoreText.text = PlayerPrefs.GetInt("playerScore", 0).ToString();
        level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver && !inSettings) { 
            if (Input.GetKeyDown(pauseKey) && !paused) {
                pauseGame();
            } else if (Input.GetKeyDown(pauseKey) && paused) {
                unPauseGame();
            }
        }
        scoreText.text = PlayerPrefs.GetInt("playerScore", 0).ToString();
    }
    public void addScore(int score) {
        playerScore = PlayerPrefs.GetInt("playerScore", 0) + score;
        PlayerPrefs.SetInt("playerScore", playerScore);
        scoreText.text = playerScore.ToString();
    }

    public void winScreen() {
        gameIsOver = true;
        Time.timeScale = 0;
        nextLevelScreen.SetActive(true);
    }
    public void loadNextScene() {
        if (level != 3) {
        SceneManager.LoadScene(level + 1);
        Time.timeScale = 1;
        } else {
            if (nameText.text.Length > 0) {
            PlayerPrefs.SetString("playerName", nameText.text);
            SceneManager.LoadScene("High Scores");
            Time.timeScale = 1;
            } else {
                warningText.SetActive(true);
            }
        }
    }

    [ContextMenu("Reset Score")]
    public void resetScore() {
        PlayerPrefs.SetInt("playerScore", 0);
        playerScore = 0;
        scoreText.text = playerScore.ToString();
    }

[ContextMenu("Pause Game")]
    public void pauseGame() {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        paused = true;
    }

[ContextMenu("Unpause")]
    public void unPauseGame() {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        paused = false;
    }

    public void backToHome() {
        resetScore();
        unPauseGame();
        SceneManager.LoadScene("Home Screen");
    }
    
    public void settings() {
        inSettings = !inSettings;
    }

    public void gameOver() {
        gameIsOver = true;
        gameOverScreen.SetActive(true);
    }

    public void playAgain() {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(level);
    }
    public void changeKey() {
        pauseKey = (KeyCode) PlayerPrefs.GetInt("pauseKey", (int) KeyCode.P);
    }
    public void updateArrows(int numArrows) {
        numArrowsText.text = numArrows.ToString();
    }
}
