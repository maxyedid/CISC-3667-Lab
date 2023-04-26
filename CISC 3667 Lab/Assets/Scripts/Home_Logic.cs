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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play() {
        SceneManager.LoadScene("Level 1");
    }

    public void setVolume(float volume) {
        music.volume = volumeControl.value;
    }
}
