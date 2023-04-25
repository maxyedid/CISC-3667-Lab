using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int playerScore;
    [SerializeField] public Text scoreText;

    public int level;

    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int score) {
        playerScore += score;
        scoreText.text = playerScore.ToString();
        if (level != 2) {
        SceneManager.LoadScene(level + 1);
        }
    }
}
