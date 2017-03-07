using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private float rows,columns,wallThick,floorWidth,floorHeight;
    // Use this for initialization
    void Start()
    {
        rows = PlayerPrefs.GetInt("rows", 1) ;
        columns = PlayerPrefs.GetInt("columns", 1);
        wallThick = PlayerPrefs.GetFloat("wallThickness");
        floorHeight = PlayerPrefs.GetFloat("floorHeight") ;
        floorWidth= PlayerPrefs.GetFloat("floorWidth");
        if(this.name == "Main Camera2")
        {
            this.transform.position = new Vector3(columns / 2, Mathf.Sqrt(Mathf.Pow(columns * floorWidth, 2) + Mathf.Pow(rows * floorHeight, 2)), -rows / 2);


        }else if (this.name == "SideView Camera")
        {
            this.transform.position = new Vector3(columns/2 , 0 , -rows*4 );
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      //  transform.position = player.transform.position + offset;

    }
}
