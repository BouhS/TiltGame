using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    void Start()
    {
        float rows = PlayerPrefs.GetInt("rows", 1) ;
        float columns = PlayerPrefs.GetInt("columns", 1);
        float floorHeight = PlayerPrefs.GetFloat("floorHeight") ;
        float floorWidth = PlayerPrefs.GetFloat("floorWidth");
        if(this.name == "Main Camera2"){
            this.transform.position = new Vector3(columns / 2, Mathf.Sqrt(Mathf.Pow(columns * floorWidth, 2) + Mathf.Pow(rows * floorHeight, 2)), -rows / 2);
        }else if (this.name == "SideView Camera"){
            this.transform.position = new Vector3(columns/2 , 0 , -rows*4 );
        }
    }
}
