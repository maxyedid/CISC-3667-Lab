using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class highScoreLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public const int NUM_HIGH_SCORES = 5;
    public const string NAME_KEY = "hiName";
    public const string SCORE_KEY = "hiScore";
    [SerializeField] Text[] names;
    [SerializeField] Text[] scores;
    int playerScore;
    string playerName;
    void Start()
    {
        playerScore = PlayerPrefs.GetInt("playerScore");
        playerName = PlayerPrefs.GetString("playerName");
        saveScores();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++) {
            names[i].text = PlayerPrefs.GetString(NAME_KEY + i);
            scores[i].text = PlayerPrefs.GetInt(SCORE_KEY + i).ToString();
        }
    }

    void saveScores() {
        for (int i = 0; i < NUM_HIGH_SCORES; i++) {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            string currentName = PlayerPrefs.GetString(currentNameKey, "");
            int currentScore = PlayerPrefs.GetInt(currentScoreKey, 0);
            if (playerScore > currentScore) {
                string tempName = currentName;
                int tempScore = currentScore;
                for (int j = i+1; j < NUM_HIGH_SCORES-1; j++) {
                     int temp = PlayerPrefs.GetInt(SCORE_KEY + j);
                     string temptemp = PlayerPrefs.GetString(NAME_KEY+j);
                     PlayerPrefs.SetString(NAME_KEY+j, tempName);
                     PlayerPrefs.SetInt(SCORE_KEY+j, tempScore);
                     tempName = temptemp;
                     tempScore = temp;
                }
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }
    }


    public void returnHome() {
        SceneManager.LoadScene("Home Screen");
    }
}
