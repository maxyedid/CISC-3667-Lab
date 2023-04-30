using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home_Logic : MonoBehaviour
{
    public AudioSource music;
    public Slider volumeControl;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        volumeControl.value = PlayerPrefs.GetFloat("volume", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void play() {
        PlayerPrefs.SetInt("playerScore", 0);
        SceneManager.LoadScene("Level 1");
    }

    public void viewScores() {
        PlayerPrefs.SetInt("playerScore", 0);
        SceneManager.LoadScene("High Scores");
    }

    public void setVolume() {
        music.volume = volumeControl.value;
        PlayerPrefs.SetFloat("volume", volumeControl.value);
    }
}
