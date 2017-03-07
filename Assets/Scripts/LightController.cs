using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    
	void Start () {
        float rows = PlayerPrefs.GetInt("rows", 1);
        float columns = PlayerPrefs.GetInt("columns", 1);
        float floorHeight = PlayerPrefs.GetFloat("floorHeight");
        float floorWidth = PlayerPrefs.GetFloat("floorWidth");
        this.transform.position = new Vector3(columns / 2, Mathf.Sqrt(Mathf.Pow(columns * floorWidth, 2) + Mathf.Pow(rows * floorHeight, 2)), -rows / 2);
        this.transform.Rotate(new Vector3(90, 0, 0));
    }
}
