using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    

	// Use this for initialization
	void Start ()
    {
        int MazeRows = PlayerPrefs.GetInt("rows");
        int MazeColumns = PlayerPrefs.GetInt("columns");
        this.gameObject.transform.position += new Vector3(0, -Mathf.Max(MazeColumns,MazeRows), 0);
        this.gameObject.transform.localScale += new Vector3(MazeColumns, 0, MazeRows);

    }
}
