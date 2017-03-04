using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject go = GameObject.Find("Main Camera2");
        transform.position = go.transform.position;
        transform.rotation = go.transform.rotation;
        /*
        int rows = PlayerPrefs.GetInt("rows", 1);
        int columns = PlayerPrefs.GetInt("columns", 1);


        Vector3 off = new Vector3(-rows / 2, 0, columns / 2);
        Vector3 pos = new Vector3(columns / 2, 2 + Mathf.Sqrt(Mathf.Pow(columns * 2 / 3, 2) + Mathf.Pow(rows * 2 / 3, 2)), -rows / 2);
        transform.position = pos + off;*/
    }

    // Update is called once per frame
    void Update () {
		
	}
}
