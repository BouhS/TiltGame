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

    public void updateText()
    {
        slideRT.text = slideR.value.ToString();
        slideCT.text = slideC.value.ToString();
    }
    /*
    public void setRowsColumnsNb(int c)
    {
        switch (c)
        {
            case 0:
                PlayerPrefs.SetInt("rows", (int)slideR.value);
                break;
            case 1:
                PlayerPrefs.SetInt("columns",(int) slideC.value);
                break;
        }

    }
    */



    public void ChangeToScene(int level)
    {
        if(level == -1)
        {
            Application.Quit();
        }else
        {
            PlayerPrefs.SetInt("rows", (int)slideR.value);
            PlayerPrefs.SetInt("columns", (int)slideC.value);
            PlayerPrefs.Save();
            SceneManager.LoadScene(level);

        }
    }

}
