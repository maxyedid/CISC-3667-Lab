using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerScore;

    public bool hasScore;
    [SerializeField] public Text scoreText;
    public int level;
    public GameObject pauseScreen;
    public bool paused = false;

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("playerScore", 0).ToString();
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !paused) {
            pauseGame();
        } else if (Input.GetKeyDown(KeyCode.P) && paused) {
            unPauseGame();
        }
    }
    public void addScore(int score) {
        playerScore = PlayerPrefs.GetInt("playerScore", 0) + score;
        PlayerPrefs.SetInt("playerScore", playerScore);
        scoreText.text = playerScore.ToString();
        if (level != 3) {
        SceneManager.LoadScene(level + 1);
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
        paused = false;
        SceneManager.LoadScene("Home Screen");
    }

}
