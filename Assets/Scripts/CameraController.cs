using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private int rows,columns;
    // Use this for initialization
    void Start()
    {

        rows = PlayerPrefs.GetInt("rows",1);
        columns = PlayerPrefs.GetInt("columns",1);


        Vector3 off = new Vector3(-rows / 2, 0, columns / 2);
        Vector3 pos = new Vector3(columns / 2, 2 + Mathf.Sqrt(Mathf.Pow(columns*2/3, 2) + Mathf.Pow(rows *2/3, 2)), - rows / 2);
        transform.position = pos + off;        
        //offset = transform.position - pos;
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      //  transform.position = player.transform.position + offset;

    }
}
