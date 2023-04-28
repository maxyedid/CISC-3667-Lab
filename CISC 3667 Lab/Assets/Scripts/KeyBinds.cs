using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinds : MonoBehaviour
{
    public Text fireText;
    public Text jumpText;
    public Text sprintText;
    public Text pauseText;
    public Event e;
    public bool changingKey = false;
    public Text currentKeyBind;
    public string currentControl;
    private MovementScript playerScript;
    private LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        try {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        } catch (Exception e) {
            e.GetType();
        }
        if (!PlayerPrefs.HasKey("fireKey")) {
            PlayerPrefs.SetInt("fireKey", (int) KeyCode.F);
            PlayerPrefs.SetInt("jumpKey", (int) KeyCode.Space);
            PlayerPrefs.SetInt("sprintKey", (int) KeyCode.LeftShift);
            PlayerPrefs.SetInt("pauseKey", (int) KeyCode.P);
        }
        KeyCode current = (KeyCode)PlayerPrefs.GetInt("fireKey");
        fireText.text = current.ToString();
        current = (KeyCode)PlayerPrefs.GetInt("jumpKey");
        jumpText.text = current.ToString();
        current = (KeyCode)PlayerPrefs.GetInt("sprintKey");
        sprintText.text = current.ToString();
        current = (KeyCode)PlayerPrefs.GetInt("pauseKey");
        pauseText.text = current.ToString();
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
          //  Debug.Log("Current Key pressed " + e.keyCode.ToString());
            changingKey = false;
            currentKeyBind.text = e.keyCode.ToString();
            PlayerPrefs.SetInt(currentControl, (int)e.keyCode);
            if (playerScript) {
            playerScript.changeKeys();
            }
            if (logic) {
                logic.changeKey();
            }
        } else if (changingKey && e.isMouse && e.type == EventType.MouseDown) {
            changingKey = false;
            KeyCode currentKey = (KeyCode)(PlayerPrefs.GetInt(currentControl));
            currentKeyBind.text = currentKey.ToString();
        }
    }
}
