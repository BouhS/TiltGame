using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public Slider slideR, slideC;
    public Text slideRT, slideCT;

    public void Start()
    {
        slideRT.text = slideR.value.ToString();
        slideCT.text = slideC.value.ToString();

    }

    /*updateText() update the text of the sliders with the values selected*/
    public void updateText()
    {
        slideRT.text = slideR.value.ToString();
        slideCT.text = slideC.value.ToString();
    }

    /*changeToScene(int level) changes the current scene to the level_scene*/
    public void ChangeToScene(int level)
    {
        if (level == -1)
        {
            Application.Quit();
        }else if (level == 0)//menu
        {
            SceneManager.LoadScene(level);
        }else
        {
            PlayerPrefs.SetInt("rows", (int)slideR.value);
            PlayerPrefs.SetInt("columns", (int)slideC.value);
            PlayerPrefs.Save();
            SceneManager.LoadScene(level);

        }
    }

}
