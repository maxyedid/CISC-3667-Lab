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

    void Start()
    {
        hasScore = PlayerPrefs.HasKey("playerScore");
        scoreText.text = (hasScore) ? PlayerPrefs.GetInt("playerScore").ToString() : scoreText.text.ToString();
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int score) {
        bool hasScore = PlayerPrefs.HasKey("playerScore");
        if (hasScore) {
            playerScore = PlayerPrefs.GetInt("playerScore") + score;
        } else {
            playerScore = score;
        }
        PlayerPrefs.SetInt("playerScore", playerScore);
        scoreText.text = playerScore.ToString();
        if (level != 2) {
        SceneManager.LoadScene(level + 1);
        }
    }

    [ContextMenu("Reset Score")]
    public void resetScore() {
        PlayerPrefs.SetInt("playerScore", 0);
        playerScore = 0;
        scoreText.text = playerScore.ToString();
    }

}
