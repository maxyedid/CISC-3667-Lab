using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home_Logic : MonoBehaviour
{
    public AudioSource music;
    public Slider volumeControl;
    public Event e;
    public bool changingKey = false;
    public Text currentKeyBind;
    public string currentControl;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("fireKey", (int) KeyCode.F);
        PlayerPrefs.SetInt("jumpKey", (int) KeyCode.Space);
        PlayerPrefs.SetInt("sprintKey", (int) KeyCode.LeftShift);
        PlayerPrefs.SetInt("pauseKey", (int) KeyCode.P);
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
    public void changeKey(Text text) {
        changingKey = true;
        currentKeyBind = text;
    }
    public void changeControl(string control) {
        currentControl = control;
    }

    void OnGUI() {
        e = Event.current;
        if (changingKey && e.isKey) {
            Debug.Log("Current Key pressed " + e.keyCode.ToString());
            changingKey = false;
            currentKeyBind.text = e.keyCode.ToString();
            PlayerPrefs.SetInt(currentControl, (int)e.keyCode);
        } else if (changingKey && e.isMouse && e.type == EventType.MouseDown) {
            changingKey = false;
            KeyCode currentKey = (KeyCode)(PlayerPrefs.GetInt(currentControl));
            currentKeyBind.text = currentKey.ToString();
        }
    }
}
