using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteMusic : MonoBehaviour
{

    public Toggle toggle;
    public AudioSource music;
    public GameObject offIcon;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        toggle.isOn = !music.mute;
        offIcon.SetActive(music.mute);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mute() {
        if (toggle.isOn) {
            music.mute = false;
            offIcon.SetActive(false);
        } else {
            music.mute = true;
            offIcon.SetActive(true);
        }
    }
}
