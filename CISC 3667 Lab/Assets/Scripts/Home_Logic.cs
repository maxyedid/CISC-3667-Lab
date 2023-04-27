using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Home_Logic : MonoBehaviour
{
    public AudioSource music;
    public Slider volumeControl;
    public Event e;
    public bool changingFire = false;
    public Text fireKeyBind;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("fireKey", (int)(KeyCode.F));
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

    public void setVolume() {
        music.volume = volumeControl.value;
        PlayerPrefs.SetFloat("volume", volumeControl.value);
    }

    public void changeFire() {
        changingFire = true;
    }

    void OnGUI() {
        e = Event.current;
        if (changingFire && e.isKey) {
            //Debug.Log("Current Key pressed " + e.keyCode.ToString());
            changingFire = false;
            fireKeyBind.text = e.keyCode.ToString();
            PlayerPrefs.SetInt("fireKey", (int)e.keyCode);
        } else if (e.isMouse && e.type == EventType.MouseDown) {
            changingFire = false;
            KeyCode currentKey = (KeyCode)(PlayerPrefs.GetInt("fireKey"));
            fireKeyBind.text = currentKey.ToString();
        }
    }
}
