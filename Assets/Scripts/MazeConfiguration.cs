﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeConfiguration : MonoBehaviour{

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void quit()
    {
        Application.Quit();
    }
}
