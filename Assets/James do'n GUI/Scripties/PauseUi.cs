using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    public GUIStyle buttonstyle;
    public GUISkin menuSkin;
    public bool paused;
    public bool showOp, mute;
    public float timer;
  //  public float Box1X, Box1Y, Box1W, Box1H;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void OnGUI()
    {

        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (paused)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(4 * scrW, 0.75f * scrH, 8 * scrW, 2 * scrH), "Paused",buttonstyle);
            GUI.skin = menuSkin;

            if (GUI.Button(new Rect(6 * scrW, 3 * scrH , 4* scrW, 1* scrH), "Resume"))
            {
               
            }

            if (GUI.Button(new Rect(6 * scrW, 4 * scrH, 4 * scrW, 1 * scrH), "Restart"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(6 * scrW, 5 * scrH, 4 * scrW, 1 * scrH), "Quit"))
            {
                Application.Quit();
            }
        }
    }
    public bool TogglePause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            return false;
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            return true;
        }
    }
}

