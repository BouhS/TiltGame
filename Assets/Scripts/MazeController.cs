using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {

    private float angleX, angleZ;
	// Use this for initialization
	void Start ()
    {
        GameObject go = GameObject.Find("MazeConfig");
        MazeConfiguration mazeConfig = go.GetComponent<MazeConfiguration>();
        transform.TransformPoint(mazeConfig.rows/2,0,-mazeConfig.columns/2);

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        angleX = transform.rotation.eulerAngles.x;
        angleZ = transform.rotation.eulerAngles.z;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if ((angleX >= 0 && angleX <= 45) || (angleX >= 315 && angleX <= 360) || (angleX < (45 + 1) && moveVertical < 0) || (angleX > (315 - 1) && moveVertical > 0))
            {
                transform.Rotate(new Vector3(moveVertical, 0, 0), Space.World);
                //     transform.RotateAround(new Vector3(MazeRows / 2, 0, -MazeColumns / 2), new Vector3(1, 0, 0), moveVertical);

            }
        }
        else
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if ((angleZ >= 0 && angleZ <= 45) || (angleZ >= 315 && angleZ <= 360) || (angleZ < (45 + 1) && moveHorizontal > 0) || (angleZ > (315 - 1) && moveHorizontal < 0))
            {
                transform.Rotate(new Vector3(0, 0, -moveHorizontal), Space.World);
                //transform.RotateAround(new Vector3(MazeRows / 2, 0, -MazeColumns / 2), new Vector3(0, 0, 1), -moveHorizontal);

            }
        }
    }
}
